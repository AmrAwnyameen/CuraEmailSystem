using Elmah;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Helpers.Notification
{
    public static class NotificationCenter
    {
        public static SmtpClient client = new SmtpClient();

        #region Services
        public static bool SendEmail(string from, string to, string subject, string body)
        {
            try
            {
                #region Configartoins
                client.UseDefaultCredentials = false;
                client.Host = ConfigurationManager.AppSettings["MailHost"].ToString();
                client.Port = int.Parse(ConfigurationManager.AppSettings["MailPort"].ToString());
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailUserName"].ToString(), ConfigurationManager.AppSettings["MailUserPassword"].ToString());
                client.EnableSsl = false;
                client.Timeout = 999999;
                client.UseDefaultCredentials = false;
                client.Host = ConfigurationManager.AppSettings["MailHost"].ToString();
                client.Port = int.Parse(ConfigurationManager.AppSettings["MailPort"].ToString());
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailUserName"].ToString(), ConfigurationManager.AppSettings["MailUserPassword"]);
                client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"].ToString());
                MailMessage msg = new MailMessage();
                msg.Subject = subject;
                #endregion

                #region Sending
                if (!string.IsNullOrEmpty(from))
                {
                    msg.From = new MailAddress(ConfigurationManager.AppSettings["MailUserName"].ToString(), "Cura-Egypt");
                }
                msg.To.Add(to);
                msg.Body = body;
                msg.IsBodyHtml = true;
                client.Send(msg);
                return true;
                #endregion

            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                return false;
            }
        }
        public static bool NotifyRecoveryEmail(string email, string username)
        {
            try
            {
                string body = "Hello";
                body += $"<br /><br />This email register as recovery Email For {username} to cura Email System successfully";
                body += "<br /><br />Thanks";
                string from = ConfigurationManager.AppSettings["senderMail"].ToString();
                string to = email;
                return SendEmail(from, to, "Cura  Notification Center", body);
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                return false;
            }

        }
        #endregion

    }
}