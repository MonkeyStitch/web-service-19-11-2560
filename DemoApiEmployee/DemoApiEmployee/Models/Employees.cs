namespace DemoApiEmployee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employees
    {
        public int ID { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Gender { get; set; }

        public decimal Salary { get; set; }
    }
}
