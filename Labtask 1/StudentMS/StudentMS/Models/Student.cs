using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMS.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        [Range(0,148)]
        public int Credit { get; set; }
        [Range(0,4)]
        public double CGPA { get; set; }
        [Required]
        public int Dept_id { get; set; }
    }
}