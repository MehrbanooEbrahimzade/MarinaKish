using Application.Validators.Ticket;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Ticket
{
    public class GetAllTicketByAllModesCommand : CommandBase
    {

        /// <summary>
        /// آی دیه سانس 
        /// </summary>
        public string FunType { get; set; }

        /// <summary>
        /// کجا خریداری شده
        /// </summary>
        public WhereBuy WhereBuy { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public Condition Condition { get; set; }



        public override bool Validate()
        {
            return new GetAllTicketByAllModesCommandValidator().Validate(this).IsValid;
        }
    }
}
