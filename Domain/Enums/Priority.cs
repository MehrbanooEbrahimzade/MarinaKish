using System.ComponentModel;

namespace Domain.Enums
{
    public enum Priority
    {
        [Description("کم")] Less =1,
        [Description("متوسط")] Medium =2,
        [Description("زیاد")] High=3
    }
}
