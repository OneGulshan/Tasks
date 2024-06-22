using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class SupplierController(DataContext context, IWebHostEnvironment environment) : Controller
    {
        private readonly DataContext _context = context;
        private readonly IWebHostEnvironment _environment = environment;

        public IActionResult Index() => View(_context.Suppliers.ToList());

        public IActionResult Report() => View(_context.Suppliers.ToList());

        public IActionResult Create(int id)
        {
            ViewBag.btn = "Create";
            if (id > 0)
            {
                ViewBag.btn = "Update";
                var Supplier = _context.Suppliers.Where(x => x.Id == id).FirstOrDefault();
                var Experience = _context.Experiences.Where(x => x.Id == id).AsNoTracking().ToList();
                Supplier.Experiences = Experience;
                return View(Supplier);
            }
            Supplier Suppliers = new();
            Suppliers.Experiences.Add(new Experience() { ExperienceId = 1 });
            return View(Suppliers);
        }

        [HttpPost]
        public IActionResult Create(Supplier sup)
        {
            int i = 0;
            string fe = Path.GetExtension(sup.PhotoFile.FileName);
            var fileLength = sup.PhotoFile.Length;
            if (fe.ToString().ToLower().Equals(".jpg", StringComparison.CurrentCultureIgnoreCase) || fe.ToString().ToLower().Equals(".png", StringComparison.CurrentCultureIgnoreCase))
            {
                if (fileLength <= 2105344)
                {
                    string fileName = null;
                    if (sup.PhotoFile != null)
                    {
                        string uploadDir = Path.Combine(_environment.WebRootPath, "Images");
                        fileName = Guid.NewGuid().ToString() + "-" + sup.PhotoFile.FileName;
                        string filePath = Path.Combine(uploadDir, fileName);

                        if (sup.Id == 0)
                        {
                            if (DateTime.Now > sup.DOB)
                            {
                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    sup.PhotoFile.CopyTo(fileStream);
                                }
                                sup.PhotoPath = fileName;

                                _context.Suppliers.Add(sup);
                                _context.SaveChanges();
                                var supId = _context.Suppliers.OrderByDescending(e => e.Id).Select(e => e.Id).FirstOrDefault();
                                sup.Code = "Sup_" + supId;
                                _context.SaveChanges();
                            }
                            else
                            {
                                TempData["Message"] = "Not applicable future date and not less than 18 years !!";
                                return RedirectToAction("Create");
                            }
                        }
                        else
                        {
                            if (DateTime.Now > sup.DOB)
                            {
                                var record = _context.Suppliers.Where(x => x.Id == sup.Id).FirstOrDefault();
                                var oldImagePath = Path.Combine(_environment.WebRootPath, "Images", record.PhotoPath);

                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    sup.PhotoFile.CopyTo(fileStream);
                                }

                                record.PhotoPath = fileName;
                                record.Code = "Sup_" + sup.Id;
                                record.FName = sup.FName;
                                record.MName = sup.MName;
                                record.LName = sup.LName;
                                record.DOB = sup.DOB;
                                record.Gender = sup.Gender;
                                record.ContactNo = sup.ContactNo;
                                record.Age = sup.Age;
                                _context.Suppliers.Update(record);
                                _context.SaveChanges();
                            }
                            else
                            {
                                TempData["Message"] = "Not applicable future date and not less than 18 years !!";
                                return RedirectToAction("Create");
                            }
                        }
                    }
                }
                else
                {
                    TempData["Message"] = "Please upload only less than 2mb size files !!";
                    return RedirectToAction("Create");
                }
            }
            else
            {
                TempData["Message"] = "Please upload only png,jpg files !!";
                return RedirectToAction("Create");
            }
            i++;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Supplier sup)
        {
            var record = _context.Suppliers.Where(x => x.Id == sup.Id).FirstOrDefault();

            _context.Suppliers.Remove(record);
            _context.SaveChanges();

            var oldImagePath = Path.Combine(_environment.WebRootPath, "Images", record.PhotoPath);

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            return RedirectToAction("Index");
        }
    }
}
