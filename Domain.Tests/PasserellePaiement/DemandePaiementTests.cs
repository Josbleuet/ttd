using Domain.PasserellePaiement;
using Moq;
using NUnit.Framework;

namespace Domain.Tests.PasserellePaiement
{
    public class DemandePaiementTests
    {
        ICompte compte;
        private ISystemePaiementBanque systemePaiement;
        private static readonly double unMontantQuelconque = 6.33;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void QuandPayer_DevraitAssurerAssezArgentAvantPayer()
        {
            ConsidererSystemePaiementFonctionnel();
            ConsidererCompteAvecAssezArgent();
            var demandeDePaiement = new DemandePaiement(compte, systemePaiement);

            demandeDePaiement.Payer(unMontantQuelconque);

            Mock.Get(compte).Verify(c => c.AAssezArgent(It.IsAny<double>()), Times.Once);
        }

        [Test]
        public void UnSystemeDePaimentFonctionnel_QuandPayer_DevraitPayer()
        {
            ConsidererSystemePaiementFonctionnel();
            ConsidererCompteAvecAssezArgent();
            var demandeDePaiement = new DemandePaiement(compte, systemePaiement);

            var isPaye = demandeDePaiement.Payer(unMontantQuelconque);

            Assert.That(isPaye, Is.True);
        }

        [Test]
        public void UnSystemeDepaimentDefectueux_QuandPayer_DevraitNePasPayer()
        {
            ConsidererSystemePaiementDefectueux();
            ConsidererCompteAvecAssezArgent();
            var demandeDePaiement = new DemandePaiement(compte, systemePaiement);

            var isPaye = demandeDePaiement.Payer(unMontantQuelconque);
            Assert.That(isPaye, Is.False);
        }

        [Test]
        public void AssezArgent_QuandPayer_DevraitPayer()
        {
            ConsidererSystemePaiementFonctionnel();
            ConsidererCompteAvecAssezArgent();
            var demandeDePaiement = new DemandePaiement(compte, systemePaiement);

            var isPaye = demandeDePaiement.Payer(unMontantQuelconque);
            Assert.That(isPaye, Is.True);
        }

        [Test]
        public void PasAssezArgent_QuandPayer_DevraitNePasPayer()
        {
            ConsidererSystemePaiementFonctionnel();
            ConsidererCompteAvecPasAssezArgent();
            var demandeDePaiement = new DemandePaiement(compte, systemePaiement);

            var isPaye = demandeDePaiement.Payer(unMontantQuelconque);

            Assert.That(isPaye, Is.False);
        }

        void ConsidererCompteAvecAssezArgent()
        {
            compte = Mock.Of<ICompte>(c => c.AAssezArgent(It.IsAny<double>()) == true);
        }

        void ConsidererCompteAvecPasAssezArgent()
        {
            compte = Mock.Of<ICompte>(c => c.AAssezArgent(It.IsAny<double>()) == false);
        }

        void ConsidererSystemePaiementFonctionnel()
        {
            systemePaiement = Mock.Of<ISystemePaiementBanque>(s => s.VerserFonds(It.IsAny<double>(), It.IsAny<ICompte>()) == true);
        }

        void ConsidererSystemePaiementDefectueux()
        {
            systemePaiement = Mock.Of<ISystemePaiementBanque>(s => s.VerserFonds(It.IsAny<double>(), It.IsAny<ICompte>()) == false);
        }

        


    }
}