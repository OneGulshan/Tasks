using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Question
    {
        [Key]
        public int QuestionsId { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Car1Q { get; set; }
        public string Car2Q { get; set; }
        public string Bike1Q { get; set; }
        public string Bike2Q { get; set; }
        public int radio { get; set; }
        public bool Car { get; set; }
        public bool Bike { get; set; }
    }
}
