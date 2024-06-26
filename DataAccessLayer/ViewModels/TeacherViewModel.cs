using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
    }
}
