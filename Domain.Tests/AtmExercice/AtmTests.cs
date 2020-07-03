using System;
using System.Collections.Generic;
using System.Text;
using Domain.AtmExercice;
using Moq;
using NUnit.Framework;

namespace Domain.Tests.AtmExercice
{
    public class AtmTests
    {
        private Atm atm;
        private Mock<ITransactionFactory> transactionFactory;
        private Account account;
        int aWithdrawalAmount = 10;

        [OneTimeSetUp]
        public void SetupAtm()
        {
            transactionFactory = new Mock<ITransactionFactory>();
            atm = new Atm(transactionFactory.Object);
            account = new Account();
        }

        [Test]
        public void ValidTransaction_WhenWithdraw_ShouldReturnsSuccess()
        {
            var transactionValid = Mock.Of<ITransactionBancaire>( t => t.Validate() == true);
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transactionValid);

            var WithdrawIsSuccess = atm.DoWithdrawal(account, aWithdrawalAmount);

            Assert.That(WithdrawIsSuccess, Is.True);
        }

        [Test]
        public void InvalidTransaction_Withdraw_ShouldReturnsFail()
        {
            var transactionInvalid = Mock.Of<ITransactionBancaire>(t => t.Validate() == false);
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transactionInvalid);

            var WithdrawIsSuccess = atm.DoWithdrawal(account, aWithdrawalAmount);

            Assert.That(WithdrawIsSuccess, Is.False);
        }
    }
}
