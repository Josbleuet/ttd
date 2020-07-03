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
            account = new Account();
        }

        [Test]
        public void ValidTransaction_WhenWithdraw_ShouldReturnsSuccess()
        {
            SetupAtmWithEnoughtOfCash();
            var transaction = GetValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            var WithdrawIsSuccess = atm.DoWithdrawal(account, aWithdrawalAmount);

            Assert.That(WithdrawIsSuccess, Is.True);
        }

        [Test]
        public void InvalidTransaction_Withdraw_ShouldReturnsFail()
        {
            SetupAtmWithEnoughtOfCash();
            var transaction = GetInValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            var WithdrawIsSuccess = atm.DoWithdrawal(account, aWithdrawalAmount);

            Assert.That(WithdrawIsSuccess, Is.False);
        }


        [Test]
        public void ValidTransaction_WhenWithdraw_ShouldProcessTransaction()
        {
            SetupAtmWithEnoughtOfCash();
            var transaction = GetValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            Mock.Get(transaction).Verify(c => c.Process(), Times.Once());
        }

        [Test]
        public void InvalidTransaction_WhenWithdraw_ShouldNotProcessTransaction()
        {
            SetupAtmWithEnoughtOfCash();
            var transaction = GetInValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            Mock.Get(transaction).Verify(c => c.Process(), Times.Never());
        }

        [Test]
        public void ValidTransaction_WhenWithdraw_ShouldDispenseWithdrawAmount()
        {
            SetupAtmWithEnoughtOfCash();
            var transaction = GetValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            cashDispenser.Verify(c => c.Dispense(aWithdrawalAmount), Times.Once());
        }

        [Test]
        public void InvalidTransaction_WhenWithdraw_ShouldNotDispense()
        {
            SetupAtmWithEnoughtOfCash();
            var transaction = GetInValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            cashDispenser.Verify(c => c.Dispense(It.IsAny<int>()), Times.Never());
        }

        [Test]
        public void ValidTransaction_WhenWithdraw_ShouldNotRollbackTransaction()
        {
            SetupAtmWithEnoughtOfCash();
            var transaction = GetValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);

            atm.DoWithdrawal(account, aWithdrawalAmount);

            Mock.Get(transaction).Verify(t => t.Rollback(), Times.Never());
        }

        [Test]
        public void DispenserOutOfCash_WhenWithdraw_ShouldRollbackTransaction()
        {
            SetupAtmOutOfCash();
            var transaction = GetValidTransaction();
            transactionFactory.Setup(f => f.Create(It.IsAny<Account>(), It.IsAny<int>())).Returns(transaction);
            cashDispenser.Setup(c => c.Dispense(It.IsAny<int>())).Throws(new OutOfMoneyException());

            atm.DoWithdrawal(account, aWithdrawalAmount);

            Mock.Get(transaction).Verify(t => t.Rollback(), Times.Once());
        }

        private ITransactionBancaire GetValidTransaction()
        {
            return Mock.Of<ITransactionBancaire>(t => t.Validate() == true);
        }
        private ITransactionBancaire GetInValidTransaction()
        {
            return Mock.Of<ITransactionBancaire>(t => t.Validate() == false);
        }
        private void SetupAtmWithEnoughtOfCash()
        {
            atm = new Atm(transactionFactory.Object, GetCashDispenserEnoughtOfCash());
        }

        private void SetupAtmOutOfCash()
        {
            atm = new Atm(transactionFactory.Object, GetCashDispenserOutOfCash());
        }

        private ICashDispenser GetCashDispenserEnoughtOfCash()
        {
            cashDispenser = new Mock<ICashDispenser>();
            cashDispenser.Setup(c => c.Dispense(It.IsAny<int>()));
            return cashDispenser.Object;
        }

        private ICashDispenser GetCashDispenserOutOfCash()
        {
            cashDispenser = new Mock<ICashDispenser>();
            cashDispenser.Setup(c => c.Dispense(It.IsAny<int>())).Throws<OutOfMoneyException>();
            return cashDispenser.Object;
        }

    }
}
