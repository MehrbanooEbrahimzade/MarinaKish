using Application.Validators.Comment;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Comment
{
    public class GetAllCommand :CommandBase
    {
        public Guid Funid { get; set; }
        public Status status { get; set; }

        public override bool Validate()
        {
            return new GetAllCommandValidator().Validate(this).IsValid;
        }
    }
}
