using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validators.Schedule
{
    public class AddSpecialOfferCommandVlidator : AbstractValidator<AddSpecialOfferCommand>
    {
        public AddSpecialOfferCommandVlidator()
        {
            RuleFor(x => x.FunId)
                .NotNull().WithMessage("لطفا ایدی تفریح را وارد کنید");


            RuleFor(x => x.AddPercent.Value)
                .GreaterThan(0).WithMessage("مقدار تخفیق باید بزرگتر از 0 تا باشد")
                .LessThanOrEqualTo(100).WithMessage("مقدار تخفیف نمیتواند بیشتر از 100 باشد");

        }
    }
}
