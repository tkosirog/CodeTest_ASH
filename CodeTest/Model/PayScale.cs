using System;
using System.Collections.Generic;

#nullable disable

namespace CodeTest.Model
{
    public partial class PayScale
    {
        public PayScale()
        {
            Employees = new HashSet<Employee>();
        }

        public int PayScaleId { get; set; }
        public int PayTypeId { get; set; }
        public decimal PayValue { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
