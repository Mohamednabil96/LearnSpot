using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDay2.Models
{
    public class Instructor
    {
        [Key]
        public int InsId { get; set; }
        public string InsName { get; set; }
        public string? InsImage { get; set; }
        public int InsSalary { get; set; }
        public string InsAddress { get; set; }

        public virtual Department? Department { get; set; }
        [ForeignKey ("Department")]
        public int DeptId { get; set; }

        public virtual Course? Course { get; set; }
        [ForeignKey("Course")]
        public int CrsId { get; set; }

    }
}
