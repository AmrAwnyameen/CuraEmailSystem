namespace Infrastructure.Helpers.Enums
{
    public enum Codes
    {
        Success = 200,
        NotValidRequest = 500,
        Error = 400,
        NotFound = 401,
        FarmRequesterTypeNotValid = 2022
    }

    public enum RequestStatusCodes
    {
        CancelRequest = 25,
        documentHandedoverToCitizen = 220,
        documentsConfirmed = 341

    }
    public enum RequestShipMentStatus
    {
        None = 0,
       VendorAdress =1,
       ReaturnAdress =1

    }

    public enum FarmsCaratShareValidtionsValues
    {
        MaxValue = 23,
    }

    public enum RequestRequiremenstMessage
    {
       valid =1,
       notValid =2
    }

    public enum Characters
    {
        agent = 0,
        authorized = 1
    }

    public enum UserFarmStatus
    {
        DocumentDeliveryToUser = 220,
       
    }


    public enum HeaderResponseCodes
    {
        serviceEntityId = 2078,
        originatingChannel=2079,
        originatingUserType=2080
    }

    public enum LookupsFarmCodes
    {
        PropertyType = 1,
        RequestType = 5,
        ActivityType = 3
    }

    public enum CustomLogicCodes
    {
        GovernorateCodeNotExist = 2097,
        SlugNotFound = 2044,
        GovernorateShipmentCodeNotExist = 2063,
        ShipmentInfoNotFound = 3001,
        attachmentCodeNotavailable = 2062,
        serviceCodeNotavailable = 2074,
        ServiceCodeSlugErrror = 3003,
        CharacterRequired= 2041,
        RequsterTypeRequired = 3005,
        FarmRequestTypeOrchardsRequired = 2021,
        CompanyInfoRequired = 3007,
        FarmNotFound = 2090,
        requestNumberNotValid= 2075,
        requestStatusNotValid = 3010,
        requestStatusComplainNotValid = 3011,
        userdoesnthaveanyfarms = 3012,
        ShipmentCodeNotavailable = 2085,
        codeServicedosnthaveanylookupvalus = 2050,
        PaymentStatusNotValid = 3015,
        Requestdosnthaveanyfees= 3016,
        ShipmentNumberNotFound = 3017,
        FilLenghtNotValid = 2067,
        agentCodes = 3018,
        authorized = 3019,
        DataOrAttchmentRequerd = 3021,
        ApplicantGovernorateCodeNotExist = 2077,
        CharacterInvalid = 2059,
        RequsterTypeNotValid= 2068,
        PropertyTypeNotValid=2020,
        RequestTypeNotValid = 2022,
        ActivityTypeNotValid = 2023,
        FarmRequestOrchardsRequired = 2051,
        PropertyTypeNotValidOrcha = 2032,
        RequestTypeNotValidOrcha = 3022,
        FarmRequestFarmRequired = 2021,
        MechanismNotValid = 3027,
        IsConfirmedNotValid = 3024,
        GovernorateSubmitNotValid = 3023,
        FarmActivityTypeRequired= 2072,
        attchmentsRequired=2066,
        StParentCodeInvalid=2094,
        NationalIdValidtions=2001,
        GreenHouseNumberRequired = 3028,
        notValid =0

    }


}