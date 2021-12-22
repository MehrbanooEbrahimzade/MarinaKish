using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.SliderPictureFun
{
    public class AddSliderPictureFunCommand
    {
        /// <summary>
        /// آیدی اسلایدها
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// عکس
        /// </summary>
        public string Attachment { get; set; }
    }
}
