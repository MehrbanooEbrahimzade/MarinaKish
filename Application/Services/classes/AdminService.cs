using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.classes
{
    public class AdminService
    {
        private readonly UserManager<User> _userManager; 
        private readonly JwtToken _jwtToken;

        public AdminService()
        {

        }
    }
}
