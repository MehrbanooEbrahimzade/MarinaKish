using System;

namespace Domain.Models
{
    public class FunSliderPicture
    {
        public FunSliderPicture(string attachment)
        {
            Id = Guid.NewGuid();
            Attachment = attachment;
        }

        
        /// <summary>
        /// آیدی اسلایدها
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// عکس
        /// </summary>
        public string Attachment { get; private set; }

        private FunSliderPicture()
        {
        }
    }
}