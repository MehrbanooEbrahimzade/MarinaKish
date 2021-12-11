using System.ComponentModel;

namespace Marina_Club.Models.enums
{
    public enum EStatus
    {
        [Description("در حال انتظار")] Waiting = 1,
        [Description("قبول شده")] Accepted = 2,
        [Description("رد شده")] Declined = 3,
        [Description("بلاک شده")] Blocked = 4
    }
}
