using Tasks.Models;
using Tasks.Data;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.Globalization;

namespace Tasks.Controllers
{
    public class CsvController : Controller
    {
        private readonly DataContext _context;
        public CsvController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index(int id)
        {
            if(id == 0)
            {
                return View(_context.Csvs.ToList());
            }
            else
            {
                var csv = _context.Csvs.Where(x => x.MemberId == id).FirstOrDefault();
                ViewBag.Bt = "Update";
                return PartialView("_Csv", csv);
            }
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Index(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, Csv csv)
        {
            if(csv.MemberId == 0)
            {
                #region Upload CSV
                string fileName = string.Empty;
                string uploadDir = Path.Combine(hostingEnvironment.WebRootPath, "files");
                fileName = file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create)) //file with filename jo create karenge
                {
                    file.CopyTo(fileStream);//now create
                    fileStream.Flush();//A file buffer is the temporary image of the file that you can edit for original file changing, that flush here
                }
                #endregion

                var Csvs = GetCsvList(file.FileName);
                return View(Csvs);
            }
            else
            {
                var c = _context.Csvs.Where(x => x.MemberId == csv.MemberId).FirstOrDefault();
                c.Email = csv.Email;
                c.StartDate = csv.StartDate;
                c.EndDate = csv.EndDate;
                _context.Csvs.Update(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        private List<Csv> GetCsvList(string fileName)
        {
            #region Read CSV //region is used for hidding and managing code in C#
            List<Csv> Csvs = new List<Csv>();
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))//StreamReader for path reading for checking is correct or not
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))//CultureInfo.InvariantCulture for reading file globally on any scripting language
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var c = csv.GetRecord<Csv>();
                    Csvs.Add(c);//csv file ki 1-1 row nikalkar model me dalkar bari-2 list of model me add karli
                    _context.Csvs.Add(c);
                    _context.SaveChanges();
                }
            }
            #endregion

            #region Create CSV
            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Csvs);
            }
            #endregion
            return Csvs;
        }

        public IActionResult Delete(int id)
        {
            var csv = _context.Csvs.Find(id);
            _context.Csvs.Remove(csv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }        
    }
}
