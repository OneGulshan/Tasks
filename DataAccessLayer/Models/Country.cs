using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Country
    {
        [Key]
        public int Cid { get; set; }
        public string CName { get; set; }
    }
}