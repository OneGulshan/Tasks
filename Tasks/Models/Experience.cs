using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        [ForeignKey("Supplier")]
        public int Id { get; set; }
        public virtual Supplier Supplier { get; private set; }
        public string Degree { get; set; }
        public string PassingYear { get; set; }
        public int Percentage { get; set; }
    }
}
