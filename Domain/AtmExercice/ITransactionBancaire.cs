namespace Domain.AtmExercice
{
    public interface ITransactionBancaire
    {
        public bool Validate();
        public void Process();
    }
}
