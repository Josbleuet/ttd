namespace Domain.AtmExercice
{
    public class TransactionBancaire : ITransactionBancaire
    {
        public TransactionBancaire(Account account, int amount)
        {
        }

        public bool Validate()
        {
            return true;
        }
    }
}
