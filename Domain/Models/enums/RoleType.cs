using System.ComponentModel;

namespace Domain.Models.enums
{
    public enum RoleTypec
    {
        [Description("خریدار")]Buyer = 1,
        [Description("فروشنده")]Seller = 2,
        [Description("ادمین")]Ad_min = 3
    }
}
