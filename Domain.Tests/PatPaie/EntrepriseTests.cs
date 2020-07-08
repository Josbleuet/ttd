using System;
using System.Collections.Generic;
using System.Text;
using Domain.PatPaie;
using Domain.PatPaie.bank;
using Moq;
using NUnit.Framework;

namespace Domain.Tests.PatPaie
{
    public class EntrepriseTests
    {
        private static readonly int WEEKS_PER_PERIOD = 4;

        private IPaymentService paymentService;
        private Entreprise entreprise;

        private Employee alice;
        private Employee bob;

        [SetUp]
        public void configurerUnServiceDePaiement()
        {
            paymentService = Mock.Of<IPaymentService>();
        }

        [SetUp]
        public void configurerEntrepriseAvecDeuxEmployes()
        {
           entreprise = new Entreprise(WEEKS_PER_PERIOD, paymentService);

            alice = Mock.Of<Employee>();
            entreprise.AddEmployee(alice);
      
            bob = Mock.Of<Employee>();
            entreprise.AddEmployee(bob);
        }


        [Test]
        public void plusieursEmployes_quandFairePaie_devraitTousLesPayer()
        {
            entreprise.PayEmployeesForOnePeriod();

            Mock.Get(alice).Verify(a => a.PayForOnePeriod(WEEKS_PER_PERIOD, paymentService), Times.Once);
            Mock.Get(bob).Verify(b => b.PayForOnePeriod(WEEKS_PER_PERIOD, paymentService), Times.Once);
        }
    }
}
