using System;
using System.Collections.Generic;
using System.Text;
using Domain.PatPaie;
using Domain.PatPaie.bank;
using Moq;
using NUnit.Framework;

namespace Domain.Tests.PatPaie
{
    public class EmployeeTests
    {
        private static readonly double ALICE_SALAIRE_ANNUEL = 50000.0;
        private static readonly int WEEKS_PER_PERIOD = 4;

        private IPaymentService paymentService;

        private BankingAccountNumber aliceAccount;
        private Employee alice;

        private readonly double anyAmount = 0.234;

        [SetUp]
        public void ConfigurerEntrepriseAvecAlice()
        {
            paymentService = Mock.Of<IPaymentService>();

            aliceAccount = new BankingAccountNumber();
            alice = new Employee(aliceAccount, ALICE_SALAIRE_ANNUEL);
        }

        [Test]
        public void UnEmploye_quandFairePaie_devraitLePayerDansSonCompte()
        {
            alice.PayForOnePeriod(WEEKS_PER_PERIOD, paymentService);
            Mock.Get(paymentService).Verify(a => a.MakePayment(It.IsAny<double>(), aliceAccount), Times.Once);
        }

        [Test]
        public void UnEmploye_quandFairePaie_devraitPayerSonSalaireBrutPourPeriode()
        {
            alice.PayForOnePeriod(WEEKS_PER_PERIOD, paymentService);

            double amount = ALICE_SALAIRE_ANNUEL / 52.0 * WEEKS_PER_PERIOD;
            Mock.Get(paymentService).Verify(a => a.MakePayment(amount, It.IsAny<BankingAccountNumber>()), Times.Once);
        }
    }
}
