namespace Domain.AtmExercice
{
    public class Atm
    {
        private readonly ITransactionFactory transactionFactory;
        public Atm(ITransactionFactory transactionFactory)
        {
            this.transactionFactory = transactionFactory;
        }

        public bool DoWithdrawal(Account account, int amount)
        {
            var transactionBancaire = transactionFactory.Create(account, amount);
            if (transactionBancaire.Validate())
            {
                return true;
            }
            return false;
        }
    }
}
