using Marina_Club.Models.enums;
using Marina_Club.Validators.Fun;
using System.Net;
using System.Web.Http;

namespace Marina_Club.Commands.Fun
{
    public class AddFunPictureCommand : CommandBase
    {
        public FunType FunType { get; set; }

        public override bool Validate()
        {
            return new AddFunPictureCommandValidator().Validate(this).IsValid;

        }
    }
}
