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
            EState = States.Open;
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
        public States EState { get;private set; }
        
        /// <summary>
        ///متد سازی وضعیت  
        /// </summary>
        public void ForStates(States states)
        {
            EState = states;
        }

        /// <summary>
        /// زمان ساخته شدن
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// آخرین فعالیت
        /// </summary>
        public DateTime LastActivity { get;private set; }

        /// <summary>
        ///متد سازی آخرین فعالیت  
        /// </summary>
        public void ForLastActivity(DateTime dateTime)
        {
            this.LastActivity = dateTime;
        }
    }
}
