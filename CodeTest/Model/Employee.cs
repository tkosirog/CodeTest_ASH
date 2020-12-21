using System;
using System.Collections.Generic;

#nullable disable

namespace CodeTest.Model
{
    public partial class Employee
    {
        public int EmployeeMetadaId { get; set; }
        public int EmployeeTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public int PayScaleId { get; set; }
        public int ManagerPayId { get; set; }

        public virtual ManagerPay ManagerPay { get; set; }
        public virtual PayScale PayScale { get; set; }
    }
}
