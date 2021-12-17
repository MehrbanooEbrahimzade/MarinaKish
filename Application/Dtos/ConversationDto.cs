using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Application.Dtos
{
    public class ConversationDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// میزان اهمیت
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// زمان ساخته شدن - شمسی
        /// </summary>
        public string CreatedTime { get; set; }

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
