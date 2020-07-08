using System;
using Domain.PatPaie.bank;

namespace Domain.PatPaie.infrastructure
{
    public class AcmePaymentService : IPaymentService
    {
        public void MakePayment(double amount, BankingAccountNumber recipient)
        {
            if (new Random().Next(100) <= 50)
            {
                throw new PaymentServiceException("Error while accessing the ACME payment service.");
            }
        }
    }
}