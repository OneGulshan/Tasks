using Microsoft.AspNetCore.Mvc;
using Tasks.Data;
using System.Diagnostics;
using Tasks.Models;
using Microsoft.EntityFrameworkCore;

namespace Tasks.Controllers
{
    public class QuestionController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

        public IActionResult Index() => View();

        public IActionResult GetQuestionList() => new JsonResult(_context.Questions.AsNoTracking().ToList());

        public IActionResult Create(Question question, int id = 1)
        {
            if (id == 1)
            {
                var ques = _context.Questions.Where(x => x.QuestionsId == id).FirstOrDefault();
                question.Question1 = ques.Question1;
                question.Question2 = ques.Question2;
                question.Question3 = ques.Question3;
                question.Car1Q = ques.Car1Q;
                question.Car2Q = ques.Car2Q;
                question.Bike1Q = ques.Bike1Q;
                question.Bike2Q = ques.Bike2Q;
                question.radio = ques.radio;
                question.Car = ques.Car;
                question.Bike = ques.Bike;
                return View(ques);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Question question)
        {
            var ques = _context.Questions.Where(x => x.QuestionsId == 1).FirstOrDefault();
            ques.Question1 = question.Question1;
            ques.Question2 = question.Question2;
            ques.Question3 = question.Question3;
            ques.Car1Q = question.Car1Q;
            ques.Car2Q = question.Car2Q;
            ques.Bike1Q = question.Bike1Q;
            ques.Bike2Q = question.Bike2Q;
            ques.radio = question.radio;
            ques.Car = question.Car;
            ques.Bike = question.Bike;
            _context.Questions.Update(ques);
            _context.SaveChanges();
            return View();
        }

        public IActionResult Delete(int id)
        {
            _context.Questions.Remove(_context.Questions.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}