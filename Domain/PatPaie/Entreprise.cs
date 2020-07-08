using System.Collections.Generic;
using Domain.PatPaie.bank;

namespace Domain.PatPaie
{
    public class Entreprise
    {
        private List<Employee> employees = new List<Employee>();
        private int weeksPerPeriod;
        private IPaymentService paymentService;

        public Entreprise(int weeksPerPeriod, IPaymentService paymentService)
        {
            this.weeksPerPeriod = weeksPerPeriod;
            this.paymentService = paymentService;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public bool HasEmployee(Employee employee)
        {
            return employees.Contains(employee);
        }

        public void PayEmployeesForOnePeriod()
        {
            foreach (var employee in employees)
            {
                employee.PayForOnePeriod(weeksPerPeriod, paymentService);
            }
        }
    }
}
