using Application.Validators.User;
using System.Net;
using System.Web.Http;

namespace Application.Commands.User
{
    public class NewMemberLoginCommand : CommandBase
    {
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// رمز عبور
        /// </summary>
        public string Password { get; set; }

        public override bool Validate()
        {
            return new NewMemberLoginCommandValidator().Validate(this).IsValid;
        }
    }
}
