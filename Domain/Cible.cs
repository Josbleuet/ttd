using System;

namespace Domain
{
    public class Cible
    {
        private Rapporteur rapporteur;

        public static int LimiteMontant = 1000;

        public Cible(Rapporteur rapporteur)
        {
            this.rapporteur = rapporteur;
        }

        public bool PreVerifier(int montant)
        {
            if (montant > LimiteMontant)
            {
                Rapporter($"WARN plus de {LimiteMontant}!");
                return false;
            }

            return true;
        }

        private void Rapporter(String msg)
        {
            rapporteur.Rapporter(msg);
        }
    }
}