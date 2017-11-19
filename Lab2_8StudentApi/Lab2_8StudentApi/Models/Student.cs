using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2_8StudentApi.Models
{
    public class Student
    {

        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string StudentIndex { get; set; }


    }
}