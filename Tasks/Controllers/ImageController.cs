using Microsoft.AspNetCore.Mvc;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class ImageController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;
        public ImageController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.Images.ToList());
        }

        public IActionResult Create(int id)
        {
            if (id > 0)
            {
                var result = _context.Images.Where(x => x.Id == id).FirstOrDefault();
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Image img)
        {
            if (ModelState.IsValid)
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
