using System.ComponentModel;


namespace Domain.Models.enums
{
    public enum FunType
    {
        [Description("پاراسل")] Paracel = 1,
        [Description("اسکی روی آب")] SkiInTheWater = 2,
        [Description("قایقرانی")] Boating = 3,
        [Description("فلای بورد")] FlyBoard = 4,
        [Description("بنانا")] Benana = 5,
        [Description("غواصی")] Diving = 6,
        [Description("کایاک پدالی")] kayakPedali = 7,
        [Description("کایاک پدالی")] kayakParooyi = 8,
        [Description("پدل بورد")] PadelBoard = 9,
        [Description("پدال بورد")] PedalBoard = 10,
        [Description("بادبانی")] BadBani = 10,
        [Description("شاتل")] shutel = 11
    }
}
