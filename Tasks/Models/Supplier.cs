using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tasks.Models
{
    public class Supplier
    {
        [Key]
        [DisplayName("Sr No")]
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
        [DisplayName("Employee Code")]
        public string Code { get; set; }
        [DisplayName("First Name")]
        public string FName { get; set; }
        [DisplayName("Middle Name")]
        public string MName { get; set; }
        [DisplayName("Last Name")]
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public Gender? Gender { get; set; }
        [DisplayName("Contact no")]
        public long ContactNo { get; set; }
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid Email Id !!")]
        [DisplayName("E-mail Id")]
        public string Email { get; set; }
        public int Age { get; set; }
        public List<Experience> Experiences { get; set; } = [];
    }
    public enum Gender
    {
        Male,
        Female,
        Others
    }
}
