using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkExamples.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        [Column("Name", TypeName = "ntext")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [NotMapped]
        public int? Age { get; set; }

        public int StdId { get; set; }

        [ForeignKey("StdId")]
        public virtual Standard Standard { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public StudentAddress Address { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
