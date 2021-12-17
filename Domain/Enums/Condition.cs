using System.ComponentModel;

namespace Domain.Enums
{
    public enum Condition
    {
        [Description("غیرفعال")] InActive = 1, // by admin
        [Description("رزرو شده")] Reservation = 2,
        [Description("لغو شده")] Cancel = 3,// by customer with penalty
        [Description("اجرا شده")] Played = 4
    }
}
