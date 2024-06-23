using Microsoft.AspNetCore.Mvc;
using Tasks.Data;
using DataAccessLayer.Models;

namespace Tasks.Controllers
{
    public class ImageController(DataContext context, IWebHostEnvironment environment) : Controller
    {
        private readonly DataContext _context = context;
        private readonly IWebHostEnvironment _environment = environment;

        public IActionResult Index() => View(_context.Images.ToList());

        public IActionResult Create(int id)
        {
            ViewBag.btn = "Create";
            if (id > 0)
            {
                ViewBag.btn = "Update";
                return View(_context.Images.Where(x => x.Id == id).FirstOrDefault());
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Image img)
        {
            if (ModelState.IsValid)
            {
                string fe = Path.GetExtension(img.ImageFile.FileName);
                var fileLength = img.ImageFile.Length;
                if (fe.ToString().ToLower().Equals(".jpg", StringComparison.CurrentCultureIgnoreCase) || fe.ToString().ToLower().Equals(".jpeg", StringComparison.CurrentCultureIgnoreCase) || fe.ToString().ToLower().Equals(".png", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (fileLength <= 2105344)
                    {
                        string fileName = null;
                        if (img.ImageFile != null)
                        {
                            string uploadDir = Path.Combine(_environment.WebRootPath, "Images");
                            fileName = Guid.NewGuid().ToString() + "-" + img.ImageFile.FileName;
                            string filePath = Path.Combine(uploadDir, fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                img.ImageFile.CopyTo(fileStream);
                            }
                            if (img.Id == 0)
                            {
                                img.ImagePath = fileName;
                                _context.Images.Add(img);
                                _context.SaveChanges();
                            }
                            else
                            {
                                var image = _context.Images.Where(x => x.Id == img.Id).FirstOrDefault();
                                var oldImagePath = Path.Combine(_environment.WebRootPath, "Images", image.ImagePath);

                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }

                                image.ImagePath = fileName;
                                _context.Images.Update(image);
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

        public IActionResult Delete(Image img)
        {
            var image = _context.Images.Where(x => x.Id == img.Id).FirstOrDefault();

            _context.Images.Remove(image);
            _context.SaveChanges();

            var oldImagePath = Path.Combine(_environment.WebRootPath, "Images", image.ImagePath);

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            return RedirectToAction("Index");
        }
    }
}
