using System;

namespace Domain.PatPaie.bank
{
    //Attention il ne faut jamais modifier IPaymentService ainsi que PaymentServiceException et BankingAccountNumber. Instruction de l'exercice.
    public class PaymentServiceException : Exception
    {
        private static readonly long serialVersionUID = 1L;

        public PaymentServiceException(String message) : base(message)
        {
        }

    }
}
