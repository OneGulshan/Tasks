using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [NotMapped]
        public string MenuName { get; set; }
        public int MenuId { get; set; }
        [NotMapped]
        public List<Menu> Menus { get; set; }
        [NotMapped]
        public List<Category> Categories { get; set; }
    }
}
