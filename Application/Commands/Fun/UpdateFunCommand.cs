using Application.Validators.Fun;
using System;
using System.Collections.Generic;
using Application.Commands.ScheduleInfo;
using Domain.Enums;
using Domain.Models;

namespace Application.Commands.Fun
{
    public class UpdateFunCommand : CommandBase
    {
        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// اطلاعات سانس
        /// </summary>
        public UpdateScheduleInfoCommand ScheduleInfo { get; set; }

        /// <summary>
        /// اسلاید عکس ها
        /// </summary>
        //public List<FunSliderPicture> PictureSlider { get; set; } ؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟؟

        /// <summary>
        /// فیلم تفریج
        /// </summary>
        public string Video { get; set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get; set; }

        /// <summary>
        /// آیکون
        /// </summary>
        public string Icon { get; private set; }
       
        /// <summary>
        /// دربار تفریح
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new UpdateFunCommandValidator().Validate(this).IsValid;
        }
    }
}
