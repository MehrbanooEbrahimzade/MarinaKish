using Marina_Club.Validators.User;
using System.Net;
using System.Web.Http;

namespace Marina_Club.Commands.User
{
    public class GetPhoneAndSetVerifyCodeCommand : CommandBase
    {
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string CellPhone { get; set; }

        public override bool Validate()
        {
            return new GetPhoneAndSetVerifyCodeCommandValidator().Validate(this).IsValid;
        }
    }
}
