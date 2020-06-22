using Moq;
using NUnit.Framework;

namespace Domain.Tests
{
    public class CibleTests
    {
        private Cible cible;
        private Rapporteur rapporteurMock;


        private static int montantSousLimite = Cible.LimiteMontant - 1;
        private static int montantEgalLimite = Cible.LimiteMontant;
        private static int montantSuperieurLimite = Cible.LimiteMontant + 1;

        [SetUp]
        public void Setup()
        {
            rapporteurMock = Mock.Of<Rapporteur>();
            cible = new Cible(rapporteurMock);
        }

        [Test]
        public void PreVerifier_MontantSousLimite_DevraitEtreApprouve()
        {
            var montant = montantSousLimite;

            var approuve = cible.PreVerifier(montant);

            Assert.That(approuve, Is.True);
        }

        [Test]
        public void PreVerifier_MontantEgalLimite_DevraitEtreApprouve()
        {
            var montant = montantEgalLimite;

            var approuve = cible.PreVerifier(montant);

            Assert.That(approuve, Is.True);
        }

        [Test]
        public void PreVerifier_MontantSuperieurLimite_DevraitEtreRefuse()
        {
            var montant = montantSuperieurLimite;

            var approuve = cible.PreVerifier(montant);

            Assert.That(approuve, Is.False);
        }
    }
}