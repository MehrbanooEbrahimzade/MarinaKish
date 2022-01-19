using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        ///  آیدی تفریح
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// اسم تفریح
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// اسلاید تفریح
        /// </summary>
        public List<FunSliderPicture> SliderPictures { get; private set; }

        /// <summary>
        /// اطلاعات سانس
        /// </summary>
        public ScheduleInfo ScheduleInfo { get; private set; }

        /// <summary>
        /// فیلم تفریح
        /// </summary>
        public string Video { get; private set; }

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


        /// <summary>
        /// آپدیت تفریح
        /// </summary>
        public void UpdateFun(string name, string about, string icon, string backgroundPicture,
            string video, /*List<FunSliderPicture> sliderPictures,*/
            TimeSpan startTime, TimeSpan endTime, int gapTime, int duration,
            int totalCapacity, int presenceCapacity, int onlineCapacity, decimal amount)
        {
            this.Name = name;
            this.About = about;
            this.Icon = icon;
            this.BackgroundPicture = backgroundPicture;
            this.Video = video;
            //this.SliderPictures = sliderPictures;
            this.ScheduleInfo.UpdateScheduleInfo(startTime, endTime, gapTime, duration, totalCapacity, presenceCapacity, onlineCapacity, amount);
        }

        public void SetIsActive(bool isActive)
        {
            this.IsActive = isActive;
        }
        private Fun()
        {
        }

    }
}
