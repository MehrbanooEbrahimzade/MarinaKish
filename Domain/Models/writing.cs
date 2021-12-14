using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public abstract class Writing
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime SubmitDate { get; set; }


    }
}
