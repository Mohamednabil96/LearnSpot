using System.ComponentModel.DataAnnotations;

namespace TaskDay2.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string? DeptName { get; set; }
        public string ManagerName { get; set; }
        public bool IsDeleted { get; set; } = false;   

        public virtual List<Instructor> Instructors { get; set; }
        public virtual List<Course> Courses { get; set; } = new List<Course>();
        public virtual List<Trainee>? Trainees { get; set; } = new List<Trainee>();

    }
}
