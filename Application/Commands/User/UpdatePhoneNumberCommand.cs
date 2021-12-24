using System;

namespace Application.Commands.User
{
    public class UpdatePhoneNumberCommand
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
    }
}
