using System.ComponentModel;

namespace Domain.Enums
{
    public enum RoleType
    {
        [Description("انتخاب نشده")] None = 0,
        [Description("خریدار")] Buyer = 1,
        [Description("فروشنده")] Seller = 2,
        [Description("ادمین")] Admin = 3
    }
}
