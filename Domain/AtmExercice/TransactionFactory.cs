namespace Domain.AtmExercice
{
    public class TransactionFactory : ITransactionFactory
    {
        public ITransactionBancaire Create(Account account, int amount)
        {
            return new TransactionBancaire(account, amount);
        }
    }
}
