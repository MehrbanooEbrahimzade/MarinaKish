using System;


namespace Application.Commands.User
{
    public class UpdateCreditCardCommand
    {

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShabaNumber { get; set; }

        /// <summary>
        /// شماره کارت 
        /// </summary>
        public string CardNumber { get; set; }

    }
}
