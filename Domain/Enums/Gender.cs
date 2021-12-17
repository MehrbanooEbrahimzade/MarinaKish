using System.ComponentModel;

namespace Domain.Enums
{
    public enum Gender
    {
        [Description("انتخاب نشده")] None = 0,
        [Description("مرد")] Man = 1,
        [Description("زن")] Woman = 2,
    }
}
