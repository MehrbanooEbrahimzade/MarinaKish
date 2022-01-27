using System;
using System.ComponentModel;
using Domain.Enums;
using Newtonsoft.Json;

namespace Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set;  }
        public string PhoneNumber { get; set; }
        public string  FullName { get; set; }
        public string  NationalCode { get; set; }
        public string ProfilePicture { get; set;  }
    }
    public class CreditCardDto
    {
        public Guid Id { get; set;  }
        public string ShabaNumber { get; set;  }
        public string  CardNumber { get; set; }
    }
}
