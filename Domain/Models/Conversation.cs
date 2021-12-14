using System;
using System.Threading.Tasks;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Conversation
    {
        public Conversation(string title)
        {
            Id = Guid.NewGuid();
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
        public EStates State { get;private set; }
        
        /// <summary>
        ///متد سازی وضعیت  //mbrk
        /// </summary>
        public void ForStates(EStates eStates)
        {
            this.State = eStates;
        }

        /// <summary>
        /// میزان اهمیت
        /// </summary>
        public EPriority Priority { get;private set; }//EPriority حذف بشه و
        //Priority هم حذف بشه




        /// <summary>
        ///متد سازی میزان اهمیت  //mbrk
        /// </summary>
        public void ForPriority(EPriority ePriority)
        {
            this.Priority = ePriority;
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
        ///متد سازی آخرین فعالیت  //mbrk
        /// </summary>
        public void ForLastActivity(DateTime dateTime)
        {
            this.LastActivity = dateTime;
        }
        
        private Conversation()
        {

        }

        //internal List<MessageDto> ToDto(List<Text> messages)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
