using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTaskTwo.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Profession { get; set; }
        [Required(ErrorMessage = "Please enter student name.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please select gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Please enter student age.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter student address.")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Please select a date ")]
        [DataType(DataType.Date)]
        public DateTime? AddmissionDate { get; set; }
        public int Fees { get; set; }
        
        

    }
}