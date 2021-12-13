using System;
using Domain.Models.enums;

namespace Domain.Models
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
        public Guid Id { get; private set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; private set; }

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
        public DateTime CreatedTime { get; private set; }
        /// <summary>
        /// آخرین فعالیت
        /// </summary>
        public DateTime LastActivity { get; set; }

        private Conversation()
        {

        }

        //internal List<MessageDto> ToDto(List<Message> messages)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
