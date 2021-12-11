using System;
using System.Net;
using System.Web.Http;
using Marina_Club.Validators.Fun;

namespace Marina_Club.Commands.Fun
{
    public class GetOneFunCommand : CommandBase
    {
        /// <summary>
        /// ID 
        /// </summary>
        public Guid Id { get; set; }

        public override bool Validate()
        {
            return new GetOneFunCommandValidator().Validate(this).IsValid;

        }
    }
}
