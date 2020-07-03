namespace Domain.AtmExercice
{
    public class Atm
    {
        private readonly ITransactionFactory transactionFactory;
        private readonly ICashDispenser cashDispenser;
        public Atm(ITransactionFactory transactionFactory, ICashDispenser cashDispenser)
        {
            this.transactionFactory = transactionFactory;
            this.cashDispenser = cashDispenser;
        }

        public bool DoWithdrawal(Account account, int amount)
        {
            var transactionBancaire = transactionFactory.Create(account, amount);
            if (transactionBancaire.Validate())
            {
                transactionBancaire.Process();

                try
                {
                    cashDispenser.Dispense(amount);
                    return true;
                }
                catch (OutOfMoneyException e)
                {
                    transactionBancaire.Rollback();
                }
            }
            return false;
        }
    }
}
