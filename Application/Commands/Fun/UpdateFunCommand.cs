using Application.Validators.Fun;
using System;
using System.Collections.Generic;
using Application.Commands.ScheduleInfo;
using Application.Commands.SliderPictureFun;
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
        /// فیلم تفریج
        /// </summary>
        public string Video { get; set; }

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get; set; }

        /// <summary>
        /// آیکون
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// دربار تفریح
        /// </summary>
        public string About { get; set; }

        

        /// <summary>
        /// اسلاید عکس ها
        /// </summary>
        public List<AddSliderPictureFunCommand> SliderPictures { get; set; }

    

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new UpdateFunCommandValidator().Validate(this).IsValid;
        }
    }
}
