using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDay2.Models
{
    public class Course
    {
        [Key]
        public int CrsId { get; set; }

        [Display(Name = "Course Name")]
        [MaxLength(25, ErrorMessage = "Course Name must be with a maximum legnth of 25 Characters")]
        [MinLength(2, ErrorMessage = "Course Name must be with a minimum Legnth of 2 Characters")]
        [UniqueCrsNamePerDept]
        public string CrsName { get; set; }

        [Display(Name = "Course Degree")]
        [Range(50,100, ErrorMessage = "Course Degree Must be between 50 and 100")]
        public int CrsDegree { get; set; }

        [Display(Name = "Course Minimum Degree")]
        [Required]
        [Remote("ValidateCrsMinDegree", "Course", AdditionalFields = "CrsDegree")]
        public int CrsMinDegree { get; set; }


        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DeptId { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual Department? Department { get; set; }
        public virtual List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public virtual List<CrsResult>? CrsResults { get; set; } = new List<CrsResult>();
    }
}
