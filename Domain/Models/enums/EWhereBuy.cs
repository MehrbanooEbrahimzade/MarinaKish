using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.enums
{
    public enum EWhereBuy
    {
        [Description("سایت")] Site = 1,
        [Description("فروشنده")] Seller = 2,
        [Description("حضوری")] Presence = 3
    }
}
