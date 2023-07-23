using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
    }
}
