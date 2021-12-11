using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Marina_Club.Commands.Fun;

namespace Marina_Club.Validators.Fun
{
    public class GetOneFunCommandValidator : AbstractValidator<GetOneFunCommand>
    {
        public GetOneFunCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آی دی مورد نظر را وارد کنید");
        }
    }
}
