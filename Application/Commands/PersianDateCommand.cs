using Application.Validators;

namespace Application.Commands
{
    public class PersianDateCommand : CommandBase
    {

        /// <summary>
        /// سال - شمسی
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// ماه - شمسی
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// روز- شمسی
        /// </summary>
        public int Day { get; set; }

        public override bool Validate()
        {
            return new PersianDateCommandValidator().Validate(this).IsValid;
        }
    }
}
