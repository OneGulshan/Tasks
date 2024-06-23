using System.ComponentModel.DataAnnotations;
namespace DataAccessLayer.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
    }
}