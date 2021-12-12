using System;

namespace Domain.Models
{
    public class CashTransfer
    {
        public CashTransfer(decimal cash,Guid userid)
        {
            Id = Guid.NewGuid();
            TransferDate = DateTime.Now;
            MarineCoin = cash;
            TransferNumber = TransferNumberGenerate();
            UserId = userid; 
        }

        /// <summary>
        /// آیدی گردش مالی
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// شماره پیگیری
        /// </summary>
        public string TransferNumber { get; private set; }

        /// <summary>
        /// زمان گردش
        /// </summary>
        public DateTime TransferDate { get; private set; }

        /// <summary>
        /// مقدار پول جابجا شده
        /// </summary>
        public decimal MarineCoin { get; private set; }

        /// <summary>
        /// موفقیت امیز بودن تراکنش
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserId { get; private set; }

        public string TransferNumberGenerate()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var second = DateTime.Now.Second.ToString();
            var RandomNum = new Random().Next(1111, 9999);
            return milisecond + RandomNum + "-" + second;
        }
        public CashTransfer()
        {

        }
        
    }
}
