using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
    }
}
