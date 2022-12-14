using System;

namespace Domain.Models
{
    public abstract class Writ
    {
  

        protected Writ(string text ,string fullname )
        {
            Id = new Guid();

            Text = text;

            FullName = fullname;

            SubmitDate = DateTime.Now;
        }



        protected Writ() { }


        public Guid Id { get; protected set; }

        public string FullName { get; protected set; }

        public string Text { get; protected set; }

        public DateTime SubmitDate { get; protected set; }


    }
}
