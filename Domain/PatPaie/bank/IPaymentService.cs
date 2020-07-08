namespace Domain.PatPaie.bank
{
    public interface IPaymentService
    {
        void MakePayment(double amount, BankingAccountNumber recipient);
    }
}
