using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Models;

namespace Application.Dtos
{
    public class FunDto
    {
        /// <summary>
        ///  آیدی تفریح
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// اسم تفریح
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// اطلاعات سانس
        /// </summary>
        public ScheduleInfoDto ScheduleInfo { get; set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; set; }

    }
}
