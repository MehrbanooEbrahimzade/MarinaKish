using Application.Validators.Fun;
using Domain.Models.enums;

namespace Application.Commands.Fun
{
    public class GetFunWithFunTypeCommand : CommandBase
    {
        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public EFunType EFunType { get; set; }

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
