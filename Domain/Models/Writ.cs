using System;

namespace Domain.Models
{
    public abstract class Writ
    {
        protected Writ(string userName, string text)
        {
            Id = new Guid();
            UserName = userName;
            Text = text;
            SubmitDate= DateTime.Now;
        }

        protected Writ() { }

        public Guid Id { get; protected set; }
        public string UserName { get; protected set; }
        public string Text { get; protected set; }
        public DateTime SubmitDate { get; protected set; }

        
    }
}
