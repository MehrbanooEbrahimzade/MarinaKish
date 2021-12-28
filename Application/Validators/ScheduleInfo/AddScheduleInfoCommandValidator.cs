using Application.Commands.ScheduleInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators.ScheduleInfo
{
    public class AddScheduleInfoCommandValidator : AbstractValidator<AddScheduleInfoCommand>
    {
        public AddScheduleInfoCommandValidator()
        {
            RuleFor(x => x.Amount)
                .NotNull().WithMessage("قیمت برای هر نفر را وارد کنید")
                .NotEmpty().WithMessage("قیمت برای هر نفر نمیتواند خالی باشد");


            RuleFor(x => x.StartTime)
                .NotNull().WithMessage("ساعت شروع سانس ها را وارد کنید")
                .NotEmpty().WithMessage("ساعت شروع سانس ها نمیتواند خالی باشد");


            RuleFor(x => x.EndTime)
                .NotNull().WithMessage("ساعت پایان سانس ها را وارد کنید")
                .NotEmpty().WithMessage("ساعت پایان سانس ها نمیتواند خالی باشد");


            RuleFor(x => x.GapTime)
                .NotNull().WithMessage("زمان استراحت هر سانس را وارد کنید")
                .NotEmpty().WithMessage("زمان استراحت هر سانس نمیتواند خالی باشد");


            RuleFor(x => x.Duration)
                .NotNull().WithMessage("مدت زمان سانس  را وارد کنید")
                .NotEmpty().WithMessage("مدت زمان سانس نمیتواند خالی باشد");


            RuleFor(x => x.OnlineCapacity)
                .NotNull().WithMessage("ظرفیت فروش آنلاین را وارد کنید")
                .NotEmpty().WithMessage("ظرفیت فروش آنلاین نمیتواند خالی باشد");


            RuleFor(x => x.PresenceCapacity)
                .NotNull().WithMessage("ظرفیت فروش حضوری را وارد کنید")
                .NotEmpty().WithMessage("ظرفیت فروش حضوری نمیتواند خالی باشد");

            RuleFor(x => x.TotalCapacity)
               .NotNull().WithMessage("ظرفیت  برای هر نفر را وارد کنید")
               .NotEmpty().WithMessage("ظرفیت برای هر نفر نمیتواند خالی باشد");

        }

    }
}
