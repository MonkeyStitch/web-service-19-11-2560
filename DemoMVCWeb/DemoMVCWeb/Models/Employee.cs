using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVCWeb.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "ชื่อ-สกุล")]
        public string FullName { get; set; }

        [Display(Name = "เพศ")]
        public string Gender { get; set; }

        [Display(Name = "เงินเดือน")]
        public decimal Salary { get; set; }

    }
}