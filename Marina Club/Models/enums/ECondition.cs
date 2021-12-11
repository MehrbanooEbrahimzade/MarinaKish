using System.ComponentModel;

namespace Marina_Club.Models.enums
{
    public enum ECondition
    {
        [Description("غیرفعال")] InActive = 1,
        [Description("رزرو شده")] Reservation = 2,
        [Description("لغو شده")] Cancel = 3,
        [Description("اجرا شده")] Played = 4
    }
}
