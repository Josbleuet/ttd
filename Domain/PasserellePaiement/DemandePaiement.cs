namespace Domain.PasserellePaiement
{
    public class DemandePaiement
    {
        private readonly ICompte _compte;
        private readonly ISystemePaiementBanque _systemePaiement;

        public DemandePaiement(ICompte compte, ISystemePaiementBanque systemePaiement)
        {
            _systemePaiement = systemePaiement;
            _compte = compte;
        }

        public bool Payer(double montant)
        {
            if (!_compte.AAssezArgent(montant))
            {
                return false;
            }

            return _systemePaiement.VerserFonds(montant, _compte);
        }
    }
}