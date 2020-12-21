using System;
using System.Collections.Generic;

#nullable disable

namespace CodeTest.Model
{
    public partial class ManagerPay
    {
        public ManagerPay()
        {
            Employees = new HashSet<Employee>();
        }

        public int ManagerPayId { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal MaxExpenseAccount { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
