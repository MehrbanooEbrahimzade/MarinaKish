using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public class AddCreditCardCommand
    {
        public Guid Id { get; set; }
        public string ShabaNumber { get; set; }
        public string CardNumber { get; set; }

    }
}
