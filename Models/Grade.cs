using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkExamples.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
