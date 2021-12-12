using System.ComponentModel;

namespace Domain.Models.enums
{
    public enum EPriority
    {
        [Description("کم")] Less = 1,
        [Description("متوسط")] Medium = 2,
        [Description("زیاد")] High = 3
    }
}
