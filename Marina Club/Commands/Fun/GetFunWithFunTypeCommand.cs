using Marina_Club.Models.enums;
using Marina_Club.Validators.Fun;

namespace Marina_Club.Commands.Fun
{
    public class GetFunWithFunTypeCommand : CommandBase
    {
        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public FunType FunType { get; set; }

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
