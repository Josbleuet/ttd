using Domain.PasserellePaiement;
using Moq;
using NUnit.Framework;

namespace Domain.Tests.PasserellePaiement
{
    public class DemandePaiementTests
    {
        ICompte compteAvecAssezArgent;
        ICompte compteAvecPasAssezArgent;
        private ISystemePaiementBanque systemePaiementFonctionnel;
        private ISystemePaiementBanque systemePaiementDefectueux;

        private static readonly double unMontantQuelconque = 6.33;


        [SetUp]
        public void Setup()
        {
            compteAvecAssezArgent = Mock.Of<ICompte>(c => c.AAssezArgent(It.IsAny<double>()) == true);
            compteAvecPasAssezArgent = Mock.Of<ICompte>(c => c.AAssezArgent(It.IsAny<double>()) == false);
            systemePaiementFonctionnel =
                Mock.Of<ISystemePaiementBanque>(s => s.VerserFonds(It.IsAny<double>(), It.IsAny<ICompte>()) == true);
            systemePaiementDefectueux =
                Mock.Of<ISystemePaiementBanque>(s => s.VerserFonds(It.IsAny<double>(), It.IsAny<ICompte>()) == false);
        }

        [Test]
        public void UnSystemeDePaimentFonctionnel_QuandPayer_DevraitPayer()
        {
            var demandeDePaiement = new DemandePaiement(compteAvecAssezArgent, systemePaiementFonctionnel);

            var isPaye = demandeDePaiement.Payer(unMontantQuelconque);
            Assert.That(isPaye, Is.True);
        }

        [Test]
        public void UnSystemeDepaimentDefectueux_QuandPayer_DevraitNePasPayer()
        {
            var demandeDePaiement = new DemandePaiement(compteAvecAssezArgent, systemePaiementDefectueux);

            var isPaye = demandeDePaiement.Payer(unMontantQuelconque);
            Assert.That(isPaye, Is.False);
        }

        [Test]
        public void AssezArgent_QuandPayer_DevraitPayer()
        {
            var demandeDePaiement = new DemandePaiement(compteAvecAssezArgent, systemePaiementFonctionnel);

            var isPaye = demandeDePaiement.Payer(unMontantQuelconque);
            Assert.That(isPaye, Is.True);
        }

        [Test]
        public void PasAssezArgent_QuandPayer_DevraitNePasPayer()
        {
            var demandeDePaiement = new DemandePaiement(compteAvecPasAssezArgent, systemePaiementFonctionnel);

            var isPaye = demandeDePaiement.Payer(unMontantQuelconque);
            Assert.That(isPaye, Is.False);
        }
    }
}