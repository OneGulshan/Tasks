using Microsoft.AspNetCore.Mvc;
using Tasks.Data;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tasks.Controllers
{
    public class ASPCOREController(DataContext context, IWebHostEnvironment environment) : Controller
    {
        private readonly DataContext _context = context;
        private readonly IWebHostEnvironment _environment = environment;

        public IActionResult Index()
        {
            var result = (from a in _context.Teachers
                          join b in _context.Countries
                          on a.Country equals b.Cid
                          join c in _context.States
                          on a.State equals c.Sid
                          select new
                          {
                              a.Id,
                              a.ImagePath,
                              b.CName,
                              c.SName
                          }).ToList();

            List<TeacherViewModel> vm = [];

            foreach (var i in result)
            {
                vm.Add(new TeacherViewModel
                {
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    CountryName = i.CName,
                    StateName = i.SName
                });
            }
            return View(vm);
        }

        public JsonResult GetStates(int CId)
        {
            var StatesList = _context.States.Where(_ => _.Cid == CId).ToList();
            ViewBag.State = new SelectList(StatesList, "Sid", "SName");
            return Json(ViewBag.State);
        }

        public IActionResult Create(int id)
        {
            ViewBag.Country = new SelectList(_context.Countries.ToList(), "Cid", "CName");
            ViewBag.btn = "Create";
            if (id > 0)
            {
                var Teacher = _context.Teachers.Where(_ => _.Id == id).FirstOrDefault();
                GetStates(Teacher.Country);
                ViewBag.btn = "Update";
                return View(Teacher);
            }
            return View(new Teacher());
        }

        [HttpPost]
        public IActionResult Create(Teacher tec)
        {
            if (ModelState.IsValid)
            {
                string fe = Path.GetExtension(tec.ImageFile.FileName);
                var fileLength = tec.ImageFile.Length;
                if (fe.ToString().ToLower().Equals(".jpg", StringComparison.CurrentCultureIgnoreCase) || fe.ToString().ToLower().Equals(".jpeg", StringComparison.CurrentCultureIgnoreCase) || fe.ToString().ToLower().Equals(".png", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (fileLength <= 2105344)
                    {
                        string fileName = null;
                        if (tec.ImageFile != null)
                        {
                            string uploadDir = Path.Combine(_environment.WebRootPath, "Images");
                            fileName = Guid.NewGuid().ToString() + "-" + tec.ImageFile.FileName;
                            string filePath = Path.Combine(uploadDir, fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                tec.ImageFile.CopyTo(fileStream);
                            }
                            if (tec.Id == 0)
                            {
                                tec.ImagePath = fileName;
                                _context.Teachers.Add(tec);
                                _context.SaveChanges();
                            }
                            else
                            {
                                var teacher = _context.Teachers.Where(x => x.Id == tec.Id).FirstOrDefault();
                                var oldImagePath = Path.Combine(_environment.WebRootPath, "Images", teacher.ImagePath);

                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }

                                teacher.ImagePath = fileName;
                                _context.Teachers.Update(teacher);
                                _context.SaveChanges();
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
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.Where(x => x.Id == id).FirstOrDefault();

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();

            var oldImagePath = Path.Combine(_environment.WebRootPath, "Images", teacher.ImagePath);

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            return RedirectToAction("Index");
        }
    }
}
