using Application.Validators.User;


namespace Application.Commands.User
{
    public class UserLoginCommand : CommandBase
    {
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// کد تاییدH
        /// </summary>
        public string VerifyCode { get; set; }

        public override bool Validate()
        {
            return new UserLoginCommandValidator().Validate(this).IsValid;
        }
    }
}
