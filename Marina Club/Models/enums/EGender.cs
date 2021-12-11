using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Models.enums
{
    public enum EGender
    {
        [Description("مرد")] Man = 1,
        [Description("زن")] WoMan = 2,
        [Description("دیگر")] Other = 3
    }
}
