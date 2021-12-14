using System.ComponentModel;

namespace Domain.Models.enums
{
    public enum RoleType
    {
        [Description("خریدار")]Buyer = 1,
        [Description("فروشنده")]Seller = 2,
        [Description("ادمین")]Admin = 3
    }
}
