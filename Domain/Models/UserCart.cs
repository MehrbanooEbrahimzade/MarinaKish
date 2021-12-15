using System;

namespace Domain.Models
{
    public class UserCart
    {
        public UserCart(string shabaNumber, string cardNumber, Guid userId)
        {
            Id = Guid.NewGuid();
            ShabaNumber = shabaNumber;
            CardNumber = cardNumber;
            UserId = userId;
        }

        public UserCart(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get;private set; }
      
        public Guid Id { get;private set; }
        public string ShabaNumber { get;private set; }
        public string CardNumber { get; private set; }

    }
}
