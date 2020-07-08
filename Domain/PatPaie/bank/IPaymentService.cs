namespace Domain.PatPaie.bank
{
    //Attention il ne faut jamais modifier IPaymentService ainsi que PaymentServiceException et BankingAccountNumber. Instruction de l'exercice.
    public interface IPaymentService
    {
        void MakePayment(double amount, BankingAccountNumber recipient);
    }
}
