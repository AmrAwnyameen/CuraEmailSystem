using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers.Security
{
    public class AESEncryptionHelper
    {
        /// <summary>
        /// the salt used to encrypt and decrypt data
        /// </summary>
        private static byte[] _salt = Encoding.ASCII.GetBytes("T8388@ibs4481M");

        /// <summary>
        /// Encrypt the given string using AES.  The string can be decrypted using 
        /// DecryptStringAES().  The sharedSecret parameters must match.
        /// </summary>
        /// <param name="plainText">The text to encrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
        public static string EncryptStringAES(string plainText, string sharedSecret)
        {
            if (plainText != null || !string.IsNullOrEmpty(plainText))
            {

                string outStr = null;                       // Encrypted string to return
                RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

                try
                {
                    // generate the key from the shared secret and the salt
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                    // Create a RijndaelManaged object
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        // prepend the IV
                        msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                        msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                        }
                        outStr = Convert.ToBase64String(msEncrypt.ToArray()).Replace('+', '-').Replace('/', '_').Replace("=", "EQUAL").Replace(",", "COMMA");
                    }
                }
                finally
                {
                    // Clear the RijndaelManaged object.
                    if (aesAlg != null)
                        aesAlg.Clear();
                }

                // Return the encrypted bytes from the memory stream.
                return outStr;
            }
            else
                return "";
        }

        /// <summary>
        /// Decrypt the given string.  Assumes the string was encrypted using 
        /// EncryptStringAES(), using an identical sharedSecret.
        /// </summary>
        /// <param name="cipherText">The text to decrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for decryption.</param>
        public static string DecryptStringAES(string cipherText, string sharedSecret)
        {
            try
            {
                if (cipherText != null || !string.IsNullOrEmpty(cipherText))
                {

                    // Declare the RijndaelManaged object
                    // used to decrypt the data.
                    RijndaelManaged aesAlg = null;

                    // Declare the string used to hold
                    // the decrypted text.
                    string plaintext = null;

                    try
                    {
                        // generate the key from the shared secret and the salt
                        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                        cipherText = cipherText.Replace('-', '+').Replace('_', '/').Replace("EQUAL", "=").Replace("COMMA", ",");
                        // Create the streams used for decryption.                
                        byte[] bytes = Convert.FromBase64String(cipherText);
                        using (MemoryStream msDecrypt = new MemoryStream(bytes))
                        {
                            // Create a RijndaelManaged object
                            // with the specified key and IV.
                            aesAlg = new RijndaelManaged();
                            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                            // Get the initialization vector from the encrypted stream
                            aesAlg.IV = ReadByteArray(msDecrypt);
                            // Create a decrytor to perform the stream transform.
                            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                                    // Read the decrypted bytes from the decrypting stream
                                    // and place them in a string.
                                    plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                    finally
                    {
                        // Clear the RijndaelManaged object.
                        if (aesAlg != null)
                            aesAlg.Clear();
                    }

                    return plaintext;
                }
                else
                    return cipherText;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Convert a stream to byte array
        /// </summary>
        /// <param name="s">the stream to convert</param>
        /// <returns>the byte array</returns>
        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }

        /// <summary>
        /// Encode string to 64 base string
        /// </summary>
        /// <param name="plainText">the string to encode</param>
        /// <returns>the encoded string</returns>
        public static string EncodeTo64(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");

            byte[] toEncodeAsBytes = ASCIIEncoding.ASCII.GetBytes(plainText);
            return (Convert.ToBase64String(toEncodeAsBytes));
        }

        /// <summary>
        /// Decode 64 base string to normal string
        /// </summary>
        /// <param name="encodedData">the encoded string</param>
        /// <returns>the decoded string</returns>
        static public string DecodeFrom64(string encodedData)
        {
            if (string.IsNullOrEmpty(encodedData))
                throw new ArgumentNullException("plainText");

            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);

            return (ASCIIEncoding.ASCII.GetString(encodedDataAsBytes));

        }

        ///// <summary>
        ///// Encrypts XML Document
        ///// </summary>
        ///// <param name="Doc">Documnet To Encrypt</param>
        ///// <param name="ElementToEncrypt">Element to Encrypt</param>
        ///// <param name="EncryptionElementID">Encryption ID</param>
        ///// <param name="Alg">Algorithm</param>
        ///// <param name="KeyName">Encryption Key Name</param>
        //public static void EncryptXML(XmlDocument Doc, string ElementToEncrypt, string EncryptionElementID, RSA Alg, string KeyName)
        //{
        //    if (Doc == null)
        //        throw new ArgumentNullException("Doc");
        //    if (ElementToEncrypt == null)
        //        throw new ArgumentNullException("ElementToEncrypt");
        //    if (EncryptionElementID == null)
        //        throw new ArgumentNullException("EncryptionElementID");
        //    if (Alg == null)
        //        throw new ArgumentNullException("Alg");
        //    if (KeyName == null)
        //        throw new ArgumentNullException("KeyName");

        //    XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;

        //    if (elementToEncrypt == null)
        //        throw new XmlException("The specified element was not found");

        //    RijndaelManaged sessionKey = null;

        //    try
        //    {
        //        sessionKey = new RijndaelManaged();
        //        sessionKey.KeySize = 256;

        //        EncryptedXml eXml = new EncryptedXml();

        //        byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);

        //        EncryptedData edElement = new EncryptedData();
        //        edElement.Type = EncryptedXml.XmlEncElementUrl;
        //        edElement.Id = EncryptionElementID;
        //        edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);

        //        EncryptedKey ek = new EncryptedKey();

        //        byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, Alg, false);

        //        ek.CipherData = new CipherData(encryptedKey);
        //        ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);


        //        DataReference dRef = new DataReference();
        //        dRef.Uri = "#" + EncryptionElementID;

        //        ek.AddReference(dRef);

        //        edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));

        //        KeyInfoName kin = new KeyInfoName();

        //        kin.Value = KeyName;

        //        ek.KeyInfo.AddClause(kin);
        //        edElement.CipherData.CipherValue = encryptedElement;
        //        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
        //    }
        //    catch (Exception error)
        //    {
        //        throw error;
        //    }
        //    finally
        //    {
        //        if (sessionKey != null)
        //        {
        //            sessionKey.Clear();
        //        }
        //    }
        //}

        ///// <summary>
        ///// Decrypt XML Documnet
        ///// </summary>
        ///// <param name="Doc">Document to Decrypt</param>
        ///// <param name="Alg">Algorithm</param>
        ///// <param name="KeyName">Key Name</param>
        //public static void DecryptXML(XmlDocument Doc, RSA Alg, string KeyName)
        //{
        //    if (Doc == null)
        //        throw new ArgumentNullException("Doc");
        //    if (Alg == null)
        //        throw new ArgumentNullException("Alg");
        //    if (KeyName == null)
        //        throw new ArgumentNullException("KeyName");

        //    EncryptedXml exml = new EncryptedXml(Doc);

        //    exml.AddKeyNameMapping(KeyName, Alg);

        //    exml.DecryptDocument();
        //}

        public static string EncryptStringTriple(string TextToEncrypt, string mysecurityKey)
        {
            byte[] MyEncryptedArray = UTF8Encoding.UTF8
               .GetBytes(TextToEncrypt);

            MD5CryptoServiceProvider MyMD5CryptoService = new
               MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
               (UTF8Encoding.UTF8.GetBytes(mysecurityKey));

            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService
               .CreateEncryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(MyEncryptedArray, 0,
               MyEncryptedArray.Length);

            MyTripleDESCryptoService.Clear();

            return Convert.ToBase64String(MyresultArray, 0,
               MyresultArray.Length);
        }

        public static string DecryptStringTriple(string TextToDecrypt, string mysecurityKey)
        {
            byte[] MyDecryptArray = Convert.FromBase64String
               (TextToDecrypt);

            MD5CryptoServiceProvider MyMD5CryptoService = new
               MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
               (UTF8Encoding.UTF8.GetBytes(mysecurityKey));

            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService
               .CreateDecryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(MyDecryptArray, 0,
               MyDecryptArray.Length);

            MyTripleDESCryptoService.Clear();

            return UTF8Encoding.UTF8.GetString(MyresultArray);
        }

    }
}
