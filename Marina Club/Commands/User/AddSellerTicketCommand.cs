using System;
using System.Net;
using System.Web.Http;
using Marina_Club.Validators.User;

namespace Marina_Club.Commands.User
{
    public class AddSellerTicketCommand : CommandBase
    {
        /// <summary>
        /// آی دیه مدل سانس ها
        /// </summary>
        public Guid ScheduleId { get; set; }

        /// <summary>
        /// تعداد بلیط
        /// </summary>
        public int NumberOfTicket { get; set; }

        /// <summary>
        /// آیدی فروشنده
        /// </summary>
        public Guid SellerId { get; set; }

        public override bool Validate()
        {
            return new AddSellerTicketCommandValidator().Validate(this).IsValid;
           
        }
    }
}
