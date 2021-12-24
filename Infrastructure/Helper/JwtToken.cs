using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helper
{
    public class JwtToken
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }
}
