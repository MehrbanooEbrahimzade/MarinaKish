using System.Collections.Generic;
using System.ComponentModel;

namespace Domain.Models.enums
{
    public enum EStatus
    {
        //public static Dictionary<string, int> DicStatus = new Dictionary<string, int>()
        //{ {"Waiting", 1}, {"Accepted", 2}, { "Declined", 3} };

        [Description("در حال انتظار")] Waiting = 1, 
        [Description("قبول شده")] Accepted = 2,
        [Description("رد شده")] Declined = 3,

        
    }
}
