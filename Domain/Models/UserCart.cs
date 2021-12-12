using System;

namespace Domain.Models
{
    public class UserCart
    {
        public UserCart(string shabaNumber, string cardNumber)
        {
            Id = Guid.NewGuid();
            ShabaNumber = shabaNumber;
            CardNumber = cardNumber;
        }
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get;private set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShabaNumber { get; private set; }

        /// <summary>
        /// شماره کارت
        /// </summary>
        public string CardNumber { get; private set; }

    }
}
