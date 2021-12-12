using Application.Validators.Fun;
using Domain.Models.enums;

namespace Application.Commands.Fun
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
