using Tasks.Repository;
using Microsoft.AspNetCore.Mvc;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class MongoDBController : Controller
    {
        private readonly IStudentRepository _stdRepo;
        public MongoDBController(IStudentRepository stdRepo)
        {
            _stdRepo = stdRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudent()
        {
            var students = _stdRepo.Gets();
            return Json(students);
        }

        public JsonResult SaveStd(Student student)
        {
            if (student.Id != null)
            {
                var std = _stdRepo.Save(student);
                return Json(std);
            }
            else
            {
                var std = _stdRepo.Save(student);
                return Json(std);
            }
        }

        public JsonResult DeleteStd(string stdId)
        {
            string message = _stdRepo.Delete(stdId);
            return Json(message);
        }
    }
}
