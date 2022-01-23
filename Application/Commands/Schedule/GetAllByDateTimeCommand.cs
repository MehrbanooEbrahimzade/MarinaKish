using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Schedule
{
    public class GetAllByDateTimeCommand : CommandBase
    {
        /// <summary>
        /// ای دیه تفریح 
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// زمان گرفته شده از فرانت که روزش فقط شنبس
        /// </summary>
        public PersianDateCommand persianDate { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
