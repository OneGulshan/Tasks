using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Country
    {
        [Key]
        public int Cid { get; set; }
        public string CName { get; set; }
    }
}