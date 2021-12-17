using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Fun
    {
        public Fun(string name, string about, string icon, string backgroundPicture,
            string video, List<FunSliderPicture> sliderPictures, ScheduleInfo scheduleInfo)
        {
            Id = Guid.NewGuid();
         
            Name = name;
            
            Icon = icon;
            
            BackgroundPicture = backgroundPicture;
            
            Video = video;
            
            SliderPictures = sliderPictures;
            
            ScheduleInfo = scheduleInfo;
            
            About = about;
            
            IsActive = true;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Video { get; private set; }

        public List<FunSliderPicture> SliderPictures { get; private set; }

        public ScheduleInfo ScheduleInfo { get; private set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// درباره تفریح
        /// </summary>
        public string About { get; private set; }

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get; private set; }

        /// <summary>
        /// آیکون
        /// </summary>
        public string Icon { get; private set; }


        private Fun() { }
    }
}
