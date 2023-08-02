using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDay2.Models
{
    public class CrsResult
    {
        [Key]
        public int CrsResultId { get; set; }
        public int? CrsResultDegree { get; set; }

        [ForeignKey("Course")]
        public int? CrsId { get; set; }

        [ForeignKey("Trainee")]
        public int? TraId { get; set; }

        [ForeignKey("CrsId")]
        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }

    }
}
