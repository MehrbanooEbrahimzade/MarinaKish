using System;
using System.Net;
using System.Web.Http;
using Application.Validators.Fun;

namespace Application.Commands.Fun
{
    public class GetOneFunCommand : CommandBase
    {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid Id { get; set; }

        public override bool Validate()
        {
            return new GetOneFunCommandValidator().Validate(this).IsValid;

        }
    }
}
