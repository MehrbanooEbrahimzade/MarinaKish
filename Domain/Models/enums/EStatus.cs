using System.ComponentModel;

namespace Domain.Models.enums
{
    public enum EStatus
    {
        [Description("در حال انتظار")] Waiting = 1,//TODO:DELETE
        [Description("قبول شده")] Accepted = 2,
        [Description("رد شده")] Declined = 3,
        [Description("بلاک شده")] Blocked = 4//TODO:DELETE
    }
}
