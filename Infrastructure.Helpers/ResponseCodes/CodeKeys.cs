using System.Collections.Generic;

namespace Infrastructure.Helpers.ResponseCodes
{
    public static class CodeKeys
    {
        public static Dictionary<string, string> SearchResponsesCodes()
        {
            var keys = new Dictionary<string, string>();

            //user
            keys.Add("2001", "NationalID is required");
            keys.Add("2002", "NationalID is Invalid(must be 14 digits and numbers only)");
            keys.Add("2003", "ServiceCode is required");
            keys.Add("2004", "ApplicantName is required");
            keys.Add("2005", "PhoneNumber is required");
            keys.Add("2006", "PhoneNumber is Invalid (must be 11 digits and numbers only)");
            keys.Add("2007", "ApplicantGovernorate is required");
            keys.Add("2008", "ApplicantAddress is required");
            keys.Add("2009", "OwnerName is required");
            keys.Add("2010", "RequestPartyName is required");
            //farm
            keys.Add("2011", "DetailedAddress is required");
            keys.Add("2012", "ActivityType is required");
            keys.Add("2013", "CommercialRegistrationNo is required");
            keys.Add("2014", "FarmGovernorate is required");
            keys.Add("2015", "FarmCity is required");
            keys.Add("2016", "FarmAddress is required");
            keys.Add("2017", "FarmPropertyType is required");
            keys.Add("2018", "FarmArea is required");
            keys.Add("2019", "FarmArea is Invalid must be numbers only");
            keys.Add("2020", "FarmPropertyType is Invalid");
            keys.Add("3028", "GreenHouseNumber is required ");
            keys.Add("3030", "FarmAcreOrchards is required");
            keys.Add("3031", "FarmCaratOrchards is required");
            keys.Add("3032", "FarmShareOrchards is required");

            //Orchards
            keys.Add("2022", "FarmRequestType is Invalid");
            keys.Add("2023", "FarmActivityType is Invalid");
            keys.Add("2024", "FarmEasternBorderOrchards is required");
            keys.Add("2025", "FarmNorthernBorderOrchards is required");
            keys.Add("2026", "FarmWesternBorderOrchards is required");
            keys.Add("2027", "FarmSouthernBorderOrchards is required");
            keys.Add("2028", "FarmGovernorateOrchards is required");
            keys.Add("2029", "FarmCityOrchards is required");
            keys.Add("2030", "FarmAddressOrchards is required");
            keys.Add("2031", "FarmPropertyTypeOrchards is required");
            keys.Add("2032", "FarmPropertyTypeOrchards is Invalid ");

            //Complaine
            keys.Add("2033", "ComplainedParty is required");
            keys.Add("2034", "TypeOfDamage is required");
            keys.Add("2035", "ComplaintSubject is required");
            keys.Add("2036", "correlationId is required");
            keys.Add("2037", "originatingChannel is required");
           
            keys.Add("2038", "ServiceSlug is required");
            keys.Add("2039", "RequestID is required");
            keys.Add("2040", "ShipmentNumber is required");
            keys.Add("2041", "Character is required");
            keys.Add("2042", "Delivery Method is required"); 
            keys.Add("2043", "AttachementCode is required");
          
            keys.Add("2044", "ServiceSlug is Invalid");
            keys.Add("2045", "FullName is required");
            keys.Add("2046", "PhoneNumber is required");
            keys.Add("2047", "Address  is required");
            keys.Add("2048", "GovernorateCode  is required");
            keys.Add("2049", "Code is required");
            keys.Add("2050", "Code is Invalid");
            keys.Add("2051", "FarmRequestTypeOrchards is required");
            keys.Add("2052", "CustomerAuthorizationAmount is required");
            keys.Add("2053", "PaymentRequestTotalAmount is required");
            keys.Add("2054", "CollectionFeesAmount is required");
              //Payments    
            keys.Add("2055", "TransactionNumber is required");
            keys.Add("2056", "PaymentRequestTotalAmount is Invalid");
            keys.Add("2057", "CollectionFeesAmount is Invalid");
            keys.Add("2058", "CustomerAuthorizationAmount is Invalid");
            keys.Add("2059", "Character is Invalid");
            keys.Add("2060", "DeliveryMethod is Invalid");
            keys.Add("2061", "AttachementName is required");
            keys.Add("2062", "AttachmentCode is Invalid");
            keys.Add("2063", "GovernorateCode  is Invalid");
         
            keys.Add("2065", "Request Number not found");
            keys.Add("2066", "Attachement is required");
            
          
            keys.Add("2069", "TimeStamp is required");
            keys.Add("2070", "Status is required");
            keys.Add("2071", "TimeStamp is Invalid");
            keys.Add("2072", "FarmActivityType is required");

      
            keys.Add("2073", "Transaction is Invalid");
            keys.Add("2074", "ServiceCode is Invalid");
            keys.Add("2075", "RequestId  is Invalid");
            

            keys.Add("2076", "ApplicantEmail  is Invalid");
            keys.Add("2077", "ApplicantGovernorate  is Invalid");
            keys.Add("2078", "serviceEntityId is Invalid");

            keys.Add("2079", "originatingChannel is Invalid");
            keys.Add("2080", "originatingUserType is Invalid");

            keys.Add("2081", "CommercialRegistration is Invalid");
            keys.Add("2082", "RequestNumber required");
            keys.Add("2083", "RequestNumber is Invalid");
            //status
            keys.Add("2084", "Status required");
            keys.Add("2085", "Status is Invalid");
            keys.Add("2086", "AuthorizationNumber is Invalid");
            keys.Add("2087", "Year is Invalid");
            keys.Add("2088", "FarmGeographicalLocation is Invalid");
            keys.Add("2089", "FarmBuildingID is Invalid");
            keys.Add("2090", "FarmID is Invalid");
            keys.Add("3029", "GreenHouseNumber is Invalid");

            keys.Add("2091", "FarmAcreOrchards is Invalid");
            keys.Add("2092", "FarmCaratOrchards is Invalid");
            keys.Add("2093", "FarmShareOrchards is Invalid");
            keys.Add("2094", "StParentCode is Invalid");

            keys.Add("2095", "SenderRequestNumber is Invalid");
            keys.Add("2096", "PaymentRequestNumber is Invalid");
            keys.Add("2097", "FarmGovernorate is Invalid");
            //user
            keys.Add("3018", "RequestPartyEmail is Invalid");
            keys.Add("3019", "ShipmenPhoneNumber is Invalid");
            keys.Add("3020", "ShipmenPhoneNumber is Invalid (must be 11 digits and numbers only)");
            keys.Add("3026", "AuthoriztionDateTime is Invalid");
            keys.Add("3025", "ReconciliationDate is Invalid");
            keys.Add("3022", "FarmRequestTypeOrchards is invalid");
            keys.Add("3023", "FarmGovernorateOrchards is Invalid");

            //Attachement
            keys.Add("2067", "Attachement is Invalid, Maximum size is 2 Mega");
            keys.Add("2068", "RequesterType  is Invalid");


            return keys;
        }
    }
}
