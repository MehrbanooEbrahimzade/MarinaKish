using System;
using Application.Validators.Ticket;
using Domain.Enums;
using Domain;
using Application.Commands.User;

namespace Application.Commands.Ticket
{
    public class AddTicketToBasketCommand : CommandBase
    {
        public string UserId { get; set; }

        /// <summary>
        /// آی دیه مدل سانس ها
        /// </summary>
        public Guid ScheduleId { get; set; }
        
        /// <summary>
        /// جنسیت خریدار
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// محل خرید بلیط
        /// </summary>
        public WhereBuy BoughtPlace { get; set; }
        

        /// <summary>
        /// اسم تفریح
        /// </summary>
        public string FunName { get; set; }


        /// <summary>
        /// Command Validation
        /// </summary>
        /// <returns>true/false</returns>
        public override bool Validate()
        {
            return new AddTicketToBasketCommandValidator().Validate(this).IsValid;
        }
    }


    public class AddSchedulToTicketCommand
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public Guid FunId { get; set; }

    }

    public class AddUserToTicketcommand
    {
        public string PhoneNumber { get; set; }

    }

}
