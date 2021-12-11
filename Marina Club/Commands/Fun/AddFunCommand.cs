using System;
using System.Web.Http;
using Marina_Club.Models.enums;
using Marina_Club.Validators.Fun;

namespace Marina_Club.Commands.Fun
{
    public class AddFunCommand : CommandBase
    {

        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public FunType FunType { get; set; }

        /// <summary>
        /// قیمت :
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// زمان شروع :
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// زمان پایان :
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// مدت زمان :
        /// </summary>
        public int SansDuration { get; set; }

        /// <summary>
        /// کل فضای سانس
        /// </summary>
        public int SansTotalCapacity { get; set; }

        /// <summary>
        /// زمان استراحت بین 2 سانس :
        /// </summary>
        public int SansGapTime { get; set; }

        /// <summary>
        /// درباره ی تفریح
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new AddFunCommandValidator().Validate(this).IsValid;
        }

    }
}
