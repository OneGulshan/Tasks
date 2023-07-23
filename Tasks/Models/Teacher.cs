using System.ComponentModel.DataAnnotations;
namespace Tasks.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
    }
}