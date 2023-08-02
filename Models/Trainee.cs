using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDay2.Models
{
    public class Trainee
    {
        [Key]
        public int TraId { get; set; }
        public string TraName { get; set; }
        public string? TraImage { get; set; }
        public string TraAddress { get; set; }
        public int TraGrade { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual List<CrsResult>? CrsResults { get; set; } = new List<CrsResult>();

    }
}
