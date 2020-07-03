namespace Domain.AtmExercice
{
    public interface ITransactionFactory
    {
        public ITransactionBancaire Create(Account account, int amount);
    }
}
