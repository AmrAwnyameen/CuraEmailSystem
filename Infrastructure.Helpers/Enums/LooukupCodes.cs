namespace Infrastructure.Helpers.Enums
{
    public enum MailTypes
    {
        New = 1,
        Sent = 2,
        Started = 3,
        Trash = 4
    }

    public enum InboxFilterType
    {
        All = 1,
        Read = 2,
        Unread = 3,
        New = 4,
        Old = 5,
        filterd = 6
    }

    public enum Paging
    {
        pageNumber = 1,
        PageSize = 50,

    }



}