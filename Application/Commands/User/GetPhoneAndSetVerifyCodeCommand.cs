using Application.Validators.User;
using System.Net;
    using System.Web.Http;

namespace Application.Commands.User
{
    public class GetPhoneAndSetVerifyCodeCommand : CommandBase
    {
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string PhoneNumber { get; set; }
        public string FullName  { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NationalCode { get; set; }


        public override bool Validate()
        {
            return new GetPhoneAndSetVerifyCodeCommandValidator().Validate(this).IsValid;
        }
    }
}
