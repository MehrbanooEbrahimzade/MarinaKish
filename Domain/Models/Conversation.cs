using System;
using Domain.Enums;


namespace Domain.Models
{
    public class Conversation
    {
        public Conversation(string title)
        {
            Id = Guid.NewGuid();
           
            Title = title;
            
            State = States.Open;
            
            CreatedTime = DateTime.Now;
            
            LastActivity = DateTime.Now;

        }

        private Conversation() { }


        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public States State { get;private set; }
       
        /// <summary>
        /// زمان ساخته شدن
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// آخرین فعالیت
        /// </summary>
        public DateTime LastActivity { get;private set; }

    }
}
