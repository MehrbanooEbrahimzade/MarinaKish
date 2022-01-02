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
        public Guid Id { get; set; }

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
            throw new NotImplementedException();
        }
    }
}
