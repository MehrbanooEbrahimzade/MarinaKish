using System.ComponentModel;

namespace Marina_Club.Models.enums
{
    public enum EMessageStatus
    {
        [Description("ارسال شده")] Sent = 1,
        [Description("ویرایش شده")] Edited = 2,
        [Description("پاک شده")] Deleted = 3
    }
}
