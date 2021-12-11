using Marina_Club.Validators.User;
using System.Net;
using System.Web.Http;

namespace Marina_Club.Commands.User
{
    public class IncreaseUserWalletCommand : CommandBase
    {
        /// <summary>
        /// مقدار افزایشی کیف پول
        /// </summary>
        public decimal Cash { get; set; }

        public override bool Validate()
        {
            return new IncreaseUserWalletCommandValidator().Validate(this).IsValid;

        }
    }
}
