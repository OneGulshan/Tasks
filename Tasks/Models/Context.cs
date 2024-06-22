using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Context
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Enrolled { get; set; }
    }
}
