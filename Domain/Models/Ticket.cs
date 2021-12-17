using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Ticket
    {
        public Ticket(string funType, Guid itemId, string phoneNumber)
        {
            Id = Guid.NewGuid();
           
            FunType = funType;
            
            ItemId = itemId;
            
            PhoneNumber = phoneNumber;
            
            Condition = Condition.InActive;
            
            SubmitDate = DateTime.Now;
            
            WhereBuy = WhereBuy.Site;
        }

        private Ticket() { }

        public Guid ItemId { get; private set; }


        public Guid Id { get; private set; }

        /// <summary>
        /// شماره تلفن همراه
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// نوع تفریح :
        /// </summary>
        public string FunType { get; private set; }
     
        /// <summary>
        /// وضعیت
        /// </summary>
        public Condition Condition { get; private set; }

        /// <summary>
        /// زمان فروش بلیط
        /// </summary>
        public DateTime SubmitDate { get; private set; }

        /// <summary>
        /// کجا خریداری شده
        /// </summary>
        public WhereBuy WhereBuy { get; private set; }
    }
}
