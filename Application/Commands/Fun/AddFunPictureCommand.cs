using Application.Validators.Fun;
using Domain.Models.enums;

namespace Application.Commands.Fun
{
    public class AddFunPictureCommand : CommandBase
    {
        public EFunType EFunType { get; set; }

        public override bool Validate()
        {
            return new AddFunPictureCommandValidator().Validate(this).IsValid;

        }
    }
}
