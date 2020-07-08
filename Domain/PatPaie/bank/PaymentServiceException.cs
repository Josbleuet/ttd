using System;

namespace Domain.PatPaie.bank
{
    public class PaymentServiceException : Exception
    {
        private static readonly long serialVersionUID = 1L;

        public PaymentServiceException(String message) : base(message)
        {
        }

    }
}
