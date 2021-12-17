using Application.Validators.User;
using System.Net;
using System.Web.Http;

namespace Application.Commands.User
{
    public class UserLoginCommand : CommandBase
    {
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// کد تاییدH
        /// </summary>
        public string Password { get; set; }

        public GetPhoneAndSetVerifyCodeCommand GetPhoneAndSetVerifyCodeCommand { get; set; }

        public override bool Validate()
        {
            return new UserLoginCommandValidator().Validate(this).IsValid;
        }
    }
}
