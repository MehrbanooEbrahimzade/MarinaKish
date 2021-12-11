using Marina_Club.Commands.ContactInfo;
using Marina_Club.Validators.User;
using System.Web.Http;

namespace Marina_Club.Commands.User
{
    public class UserSignUpCommand : CommandBase
    {
        /// <summary>
        /// نام :
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی :
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// نام کاربری :
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// رمز عبور :
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// استان :
        /// </summary>
        public string Provice { get; set; }

        /// <summary>
        /// شماره ملی :
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// شماره کارت :
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// اطلاعات کانتکت کاربر
        /// </summary>
        public AddContactInfoCommand ContactInfo { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new UserSignUpCommandValidator().Validate(this).IsValid;

        }
    }
}
