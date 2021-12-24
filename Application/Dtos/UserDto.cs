using System;
using Domain.Enums;

namespace Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set;  }
        public string PhoneNumber { get; set; }
        public string  FullName { get; set; }
        public string  NationalCode { get; set; }
        public string  BirthDate { get; set; }
        public CreditCardDto CreditCard { get; set;  }
    }
    public class CreditCardDto
    {
        public Guid Id { get; set;  }
        public string ShabaNumber { get; set;  }
        public string  CardNumber { get; set; }
    }
}
