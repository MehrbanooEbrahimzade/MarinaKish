using System.ComponentModel;

namespace Domain.Enums
{
    public enum MessageStatus
    {
        [Description("ارسال شده")] Sent = 1,
        [Description("ویرایش شده")] Edited = 2,
        [Description("پاک شده")] Deleted = 3
    }
}
