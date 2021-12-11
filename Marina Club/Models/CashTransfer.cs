using System;

namespace Marina_Club.Models
{
    public class CashTransfer
    {
        public CashTransfer(decimal cash)
        {
            TransferDate = DateTime.Now;
            MarineCoin = cash;
            TransferNumber = TransferNumberGenerate();
        }

        /// <summary>
        /// آیدی گردش مالی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// شماره پیگیری
        /// </summary>
        public string TransferNumber { get; set; }

        /// <summary>
        /// زمان گردش
        /// </summary>
        public DateTime TransferDate { get; set; }

        /// <summary>
        /// مقدار پول جابجا شده
        /// </summary>
        public decimal MarineCoin { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserId { get; set; }

        public string TransferNumberGenerate()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var second = DateTime.Now.Second.ToString();
            var RandomNum = new Random().Next(1111, 9999);
            return milisecond + RandomNum + "-" + second;
        }

        private CashTransfer()
        {

        }
    }
}
