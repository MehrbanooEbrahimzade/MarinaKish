using Marina_Club.Models.enums;
using System;
using System.Collections.Generic;

namespace Marina_Club.Dtos
{
    public class ConversationDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// میزان اهمیت
        /// </summary>
        public EPriority Priority { get; set; }

        /// <summary>
        /// زمان ساخته شدن - شمسی
        /// </summary>
        public string ShamsiCreatedTime { get; set; }

        /// <summary>
        /// اخرین فعالیت - به شمسی
        /// </summary>
        public string ShamsiLastActivity { get; set; }

        /// <summary>
        /// پیام ها
        /// </summary>
        public List<MessageDto> RecentMessages { get; set; }
    }
}
