using System.ComponentModel;

namespace Domain.Models.enums
{
    public enum EStatus
    {
        [Description("در حال انتظار")] Waiting = 1,
        [Description("قبول شده")] Accepted = 2,
        [Description("رد شده")] Declined = 3,
    }
}
