using Marina_Club.Models.enums;
using System;

namespace Marina_Club.Models
{
    public class Conversation
    {
        public Conversation(string title)
        {
            Title = title;
            State = EStates.Open;
            Priority = EPriority.Less;
            CreatedTime = DateTime.Now;
            LastActivity = DateTime.Now;

        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public EStates State { get; set; }

        /// <summary>
        /// میزان اهمیت
        /// </summary>
        public EPriority Priority { get; set; }

        /// <summary>
        /// زمان ساخته شدن
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// آخرین فعالیت
        /// </summary>
        public DateTime LastActivity { get; set; }

        private Conversation() {   }

        //internal List<MessageDto> ToDto(List<Message> messages)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
