using Application.Validators.Fun;
using System;

namespace Application.Commands.Fun
{
    public class AddFileToFunCommand : CommandBase
    {
        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// آیدی عکس
        /// </summary>
        public Guid FileId { get; set; }

        public override bool Validate()
        {
            return new AddFileToFunCommandValidator().Validate(this).IsValid;
        }
    }
}
