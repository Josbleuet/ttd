using Domain.PatPaie.bank;

namespace Domain.PatPaie
{
    public class Employee
    {
        private BankingAccountNumber bankingAccount;
        private double annualSalary;

        public Employee(BankingAccountNumber bankingAccount, double annualSalary)
        {
            this.bankingAccount = bankingAccount;
            this.annualSalary = annualSalary;
        }

        public BankingAccountNumber GetAccountNumber()
        {
            return bankingAccount;
        }

        public double GetAnnualSalary()
        {
            return annualSalary;
        }

        public void PayForOnePeriod(double weeksPerPeriod, IPaymentService paymentService)
        {
            double rawSalary = annualSalary / 52.0 * weeksPerPeriod;
            paymentService.MakePayment(rawSalary, bankingAccount);
        }
    }
}
