using System;

namespace Domain.Models
{
    public class FunSliderPicture
    {
        public FunSliderPicture(Guid id, string attachment)
        {
            Id = id;
          
            Attachment = attachment;
        }

        private FunSliderPicture() { }
       
        
        public Guid Id { get; private set; }

        /// <summary>
        /// عکس
        /// </summary>
        public string Attachment { get; private set; }
    }
}