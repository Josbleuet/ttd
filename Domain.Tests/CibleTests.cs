using Moq;
using NUnit.Framework;

namespace Domain.Tests
{
    public class CibleTests
    {
        private Cible cible;
        private Rapporteur rapporteurMock;
        private Rapporteur rapporteurPleinMock;


        private static int montantPeuImporte = 123;
        private static int montantSousLimite = Cible.LimiteMontant - 1;
        private static int montantEgalLimite = Cible.LimiteMontant;
        private static int montantSuperieurLimite = Cible.LimiteMontant + 1;

        [SetUp]
        public void Setup()
        {
            rapporteurMock = Mock.Of<Rapporteur>(r => r.EstPlein() == false);
            rapporteurPleinMock = Mock.Of<Rapporteur>( r => r.EstPlein() == true);
        }

        [Test]
        public void PreVerifier_MontantSousLimite_DevraitEtreApprouve()
        {
            cible = new Cible(rapporteurMock);
            var montant = montantSousLimite;

            var approuve = cible.PreVerifier(montant);

            Assert.That(approuve, Is.True);
        }

        [Test]
        public void PreVerifier_MontantEgalLimite_DevraitEtreApprouve()
        {
            cible = new Cible(rapporteurMock);
            var montant = montantEgalLimite;

            var approuve = cible.PreVerifier(montant);

            Assert.That(approuve, Is.True);
        }

        [Test]
        public void PreVerifier_MontantSuperieurLimite_DevraitEtreRefuse()
        {
            cible = new Cible(rapporteurMock);
            var montant = montantSuperieurLimite;

            var approuve = cible.PreVerifier(montant);

            Assert.That(approuve, Is.False);
        }

        [Test]
        public void PreVerifier_RapporterEstPlein_DevraitEtreRefuse()
        {
            cible = new Cible(rapporteurPleinMock);
            var montant = montantPeuImporte;

            var approuve = cible.PreVerifier(montant);

            Assert.That(approuve, Is.False);
        }

    }
}