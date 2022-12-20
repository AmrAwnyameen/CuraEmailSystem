namespace Infrastructure.Helpers.Enums
{
    public enum ShipmentInfoCodes
    {
        Shipmentdelivered = 53 ,
        DocumentSubmitted = 340,
        thePersonHowSentToHimDeliveryNotFound = 112,
        theShipmentResenToPostalAgain = 342
    }

    public enum ShipmentDelivery { 
        Postal = 1,
        notFound = 0
    }

    public enum PaymentDeliveryCodes
    {
        CompeletedPostalPayment = 27,
        RequiredPostalPayment = 26
    }


}