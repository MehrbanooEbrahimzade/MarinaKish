using System;

namespace Application.Dtos
{
    public class CashTransferDto
    {
        /// <summary>
        /// آیدی گردش مالی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// شماره پیگیری
        /// </summary>
        public string TransferNumber { get; set; }

        /// <summary>
        /// زمان گردش - به شمسی
        /// </summary>
        public string PersianTransferDate { get; set; }

        /// <summary>
        /// مقدار پول جابجا شده
        /// </summary>
        public decimal MarineCoin { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserId { get; set; }
    }
}
