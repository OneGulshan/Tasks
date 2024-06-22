using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksAPI.Models
{
    public class Blob
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public IFormFile BlobImage { get; set; }
        public string BlobImagePath { get; set; }
    }
}
