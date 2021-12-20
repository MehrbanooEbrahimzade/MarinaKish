using System;
using Domain.Enums;

namespace Application.Dtos
{
    public class UserDto
    {
        public string PhoneNumber { get; set; }
        public string  FullName { get; set; }
        public string  NationalCode { get; set; }
        public string  BirthDate { get; set; }
    }
}
