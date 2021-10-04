using System;
using System.Collections.Generic;

#nullable disable

namespace TestCQRS.Models
{
    public partial class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? JoiningDate { get; set; }
        public long DepartmentId { get; set; }
        public bool IsActive { get; set; }

        public virtual Department Department { get; set; }
    }
}
