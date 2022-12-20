namespace Infrastructure.Helpers.Enums
{
    public enum ValidtionStatusRequired
    {
        DocumentsRequiredCompleted = 8,
        DataCorrectionRequired= 15,
        RequiredCompletePaperworkNDCorrectData = 17,
    }

    public enum ValidtionStatusRequiredAttachments
    {
        DocumentsRequiredCompleted = 8,
        RequiredCompletePaperworkNDCorrectData = 17,
    }

    public enum ValidtionStatusUpload
    {
        DocumentsRequiredCompleted = 8,
        RequiredCompletePaperworkNDCorrectData = 17,
    }

    public enum ValidtionStatusCompeleted
    {
        DocumentsCompleted = 14,
        DataCorrectionCompleted = 16,
        PaperworkNDCorrectDataComplete = 18,
        PaymentCompeleted = 22,
    }

    public enum ValidtionStatusCompeletedInquery
    {
        DocumentsCompleted = 14,
        DataCorrectionCompleted = 16,
        PaperworkNDCorrectDataComplete = 18,
        PaymentCompeleted = 22,
        UnderStudying = 4,
    }

    public enum ValidtionStatusPayment
    {
        PaymentRequired = 21,
        PaymentCompeleted = 22,
    }

    public enum ValidtionPaymentStatus
    {
        PaymentRequired = 21,
        newRequest = 2,
    }

    public enum ConfirmAuthorizingMechanism
    {
      Card,
      Channel,
      Meeza
    }

    public enum ConfirmIsConfirmed
    {
        Yes
           ,
        No
    }
}
