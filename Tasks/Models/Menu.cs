using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
    }
}
