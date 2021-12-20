using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public class CompleteProfileCommand
    {
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set;  }
    }
}
