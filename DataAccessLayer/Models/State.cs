using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class State
    {
        [Key]
        public int Sid { get; set; }
        public int Cid { get; set; }
        public string SName { get; set; }
    }
}