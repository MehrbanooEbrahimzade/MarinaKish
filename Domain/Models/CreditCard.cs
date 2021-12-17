using System;

namespace Domain.Models
{
    public class CreditCard
    {
        public static CreditCard Empty => new CreditCard(string.Empty, string.Empty, Guid.Empty);

        public CreditCard(string shabaNumber, string cardNumber, Guid userId)
        {
            Id = Guid.NewGuid();
            ShabaNumber = shabaNumber;
            CardNumber = cardNumber;
            UserId = userId;
        }

        private CreditCard() { }

        public Guid UserId { get; private set; }

        public Guid Id { get; private set; }
        public string ShabaNumber { get; private set; }
        public string CardNumber { get; private set; }

    }
}
