using System.ComponentModel;

namespace Domain.Enums
{
    public enum WhereBuy
    {
        [Description("سایت")] Site = 1,
        [Description("فروشنده")] Seller = 2,
        [Description("حضوری")] Presence = 3
    }
}
