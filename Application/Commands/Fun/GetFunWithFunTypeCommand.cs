using Application.Validators.Fun;
using Domain.Enums;

namespace Application.Commands.Fun
{
    public class GetFunWithFunTypeCommand : CommandBase
    {
        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public FunType EFunType { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        /// <returns>True/False</returns>
        public override bool Validate()
        {
            return new GetFunWithFunTypeCommandValidator().Validate(this).IsValid;
        }
    }
}
