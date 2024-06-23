using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class City
    {
        [Key]
        public int City_Id { get; set; }
        public string City_Name { get; set; }
        public int S_Id { get; set; }
    }
}
