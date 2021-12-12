using Application.Validators.Fun;
using System;
using Domain.Models.enums;

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
        /// 
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
            return new UpdateFunCommandValidator().Validate(this).IsValid;
        }
    }
}
