using Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Marina_Club.Activator
{
    public static class TokenExtensions
    {
        public static UserInfo GetUserClaim(this ClaimsIdentity claimsIdentity)
        {
            return new UserInfo
            {
                Id = Guid.Parse(claimsIdentity.FindFirst("id").Value),
                PhoneNumber = claimsIdentity.FindFirst(ClaimTypes.MobilePhone)?.Value
            };
        }
    }
}
