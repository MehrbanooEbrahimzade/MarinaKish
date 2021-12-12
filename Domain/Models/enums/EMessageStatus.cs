using System.ComponentModel;

namespace Domain.Models.enums
{
    public enum EMessageStatus
    {
        [Description("ارسال شده")] Sent = 1,
        [Description("ویرایش شده")] Edited = 2,
        [Description("پاک شده")] Deleted = 3
    }
}
