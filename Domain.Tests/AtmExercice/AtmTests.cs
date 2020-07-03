using Domain.AtmExercice;
using Moq;
using NUnit.Framework;

namespace Domain.Tests.AtmExercice
{
    public class AtmTests
    {
        private Atm atm;
        private Mock<ITransactionFactory> transactionFactory;
        private Mock<ICashDispenser> cashDispenser;
        private Account account;
        int aWithdrawalAmount = 10;

        [OneTimeSetUp]
        public void SetupAtm()
        {
            transactionFactory = new Mock<ITransactionFactory>();
            cashDispenser = new Mock<ICashDispenser>();
            atm = new Atm(transactionFactory.Object, cashDispenser.Object);
            account = new Account();
        }

        [Test]
        public void ValidTransaction_WhenWithdraw_ShouldReturnsSuccess()
        {
            var transaction = GetValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            var WithdrawIsSuccess = atm.DoWithdrawal(account, aWithdrawalAmount);

            Assert.That(WithdrawIsSuccess, Is.True);
        }

        [Test]
        public void InvalidTransaction_Withdraw_ShouldReturnsFail()
        {
            var transaction = GetInValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            var WithdrawIsSuccess = atm.DoWithdrawal(account, aWithdrawalAmount);

            Assert.That(WithdrawIsSuccess, Is.False);
        }


        [Test]
        public void ValidTransaction_WhenWithdraw_ShouldProcessTransaction()
        {
            var transaction = GetValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            Mock.Get(transaction).Verify(c => c.Process(), Times.Once());
        }

        [Test]
        public void InvalidTransaction_WhenWithdraw_ShouldNotProcessTransaction()
        {
            var transaction = GetInValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            Mock.Get(transaction).Verify(c => c.Process(), Times.Never());
        }

        [Test]
        public void ValidTransaction_WhenWithdraw_ShouldDispenseWithdrawAmount()
        {
            var transaction = GetValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            cashDispenser.Verify(c => c.Dispense(aWithdrawalAmount), Times.Once());
        }

        [Test]
        public void InvalidTransaction_WhenWithdraw_ShouldNotDispense()
        {
            var transaction = GetInValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            cashDispenser.Verify(c => c.Dispense(It.IsAny<int>()), Times.Never());
        }

        private ITransactionBancaire GetValidTransaction()
        {
            return Mock.Of<ITransactionBancaire>(t => t.Validate() == true);
        }
        private ITransactionBancaire GetInValidTransaction()
        {
            return Mock.Of<ITransactionBancaire>(t => t.Validate() == false);
        }
    }
}
