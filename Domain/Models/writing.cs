using System;

namespace Domain.Models
{
    public class Writing
    {
        public Guid Id { get;protected set; }
        public string UserName { get; protected set; }
        public string Text { get; protected set; }
        public DateTime SubmitDate { get; protected set; }


    }
}
