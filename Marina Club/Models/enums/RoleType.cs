﻿using System.ComponentModel;

namespace Marina_Club.Models.enums
{
    public enum RoleTypec
    {
        [Description("خریدار")]Buyer = 1,
        [Description("فروشنده")]Seller = 2,
        [Description("ا.د.مین")]Ad_min = 3
    }
}
