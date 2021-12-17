using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class EmailSetting
    {
        public bool DefaultCredentials { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string SMTPServer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string DisplayName { get; set; }
    }
}
