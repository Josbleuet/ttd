namespace Domain.PasserellePaiement
{
    public interface ISystemePaiementBanque
    {
        bool VerserFonds(double montant, ICompte compte);
    }
}
