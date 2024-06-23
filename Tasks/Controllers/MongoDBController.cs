using Tasks.Repository;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;

namespace Tasks.Controllers
{
    public class MongoDBController(IStudentRepository stdRepo) : Controller
    {
        private readonly IStudentRepository _stdRepo = stdRepo;
        public IActionResult Index() => View();
        public JsonResult GetStudent() => Json(_stdRepo.Gets());
        public JsonResult SaveStd(Student student) => Json(_stdRepo.Save(student));
        public JsonResult DeleteStd(string stdId) => Json(_stdRepo.Delete(stdId));
    }
}
