using Application.Commands.ScheduleInfo;
using Application.Commands.SliderPictureFun;
using Application.Validators.Fun;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application.Commands.Fun
{
    public class AddFunCommand : CommandBase
    {
        
        /// <summary>
        /// اسم تفریج
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// اسلاید تفریحات
        /// </summary>
        public List<AddSliderPictureFunCommand> SliderPicture { get; set; }
    
        /// <summary>
        /// اطلاعات سانس
        /// </summary>
        public AddScheduleInfoCommand ScheduleInfo { get; set; }
        
        /// <summary>
        /// فیلم تفریح
        /// </summary>
        public string Video { get; set; }
        
        /// <summary>
        /// دربار تفریح
        /// </summary>
        public string About { get; set; }
        
        /// <summary>
        /// عکس بک گراند
        /// </summary>
        public string BackgroundPicture { get; set; }
        
        /// <summary>
        /// آیکون تفریح
        /// </summary>
        public string Icon { get; set; }



        public override bool Validate()
        {
            return new AddFunCommandValidator().Validate(this).IsValid;
        }

    }
}
