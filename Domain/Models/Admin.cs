using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Admin : User
    {
        public Admin(string email) : base(email)
        {
            Email = email;
             
        }
        
    }
}
