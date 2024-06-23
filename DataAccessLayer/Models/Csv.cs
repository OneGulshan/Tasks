using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Csv
    {
        [Key]
        [CsvHelper.Configuration.Attributes.Index(0)]
        public int MemberId { get; set; }
        [CsvHelper.Configuration.Attributes.Index(1)]
        public string Email { get; set; } = "";
        [CsvHelper.Configuration.Attributes.Index(2)]
        public string StartDate { get; set; } = "";
        [CsvHelper.Configuration.Attributes.Index(3)]
        public string EndDate { get; set; } = "";
    }
}
