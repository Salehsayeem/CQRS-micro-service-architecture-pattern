using System;
using System.Collections.Generic;

#nullable disable

namespace TestCQRS.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
