using System.Net;
using System.Web.Http;
using Application.Validators.User;

namespace Application.Commands.User
{
    public class AddSellerInfoCommand : CommandBase
    {
        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// شماره کارت
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShabaNumber { get; set; }

        public override bool Validate()
        {
            return new AddSellerInfoCommandValidator().Validate(this).IsValid;
            
        }
    }
}
