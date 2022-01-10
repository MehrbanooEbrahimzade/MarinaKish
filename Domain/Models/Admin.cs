using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Admin : User
    {
        public Admin(string email, string password) : base(email)
        {
            Email = email;
            PasswordHash = password; 
        }
        
    }
}
