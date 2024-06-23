using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;

namespace Tasks.Controllers
{
    public class CascadeDropDownListController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

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
                              b.CName,
                              c.SName
                          }).AsNoTracking().ToList();

            List<TeacherViewModel> vm = [];//Its Required Because in Model Teacher not available CName & SName so.

            foreach (var i in result)
            {
                vm.Add(new TeacherViewModel
                {
                    Id = i.Id,
                    CountryName = i.CName,
                    StateName = i.SName
                });
            }
            return View(vm);
        }

        public JsonResult GetStates(int CId)
        {
            var StatesList = _context.States.Where(_ => _.Cid == CId).AsNoTracking().ToList();
            ViewBag.State = new SelectList(StatesList, "Sid", "SName");
            return Json(ViewBag.State);
        }

        public IActionResult Create(int id)
        {
            ViewBag.Country = new SelectList(_context.Countries.ToList(), "Cid", "CName");

            if (id > 0)
            {
                var Teacher = _context.Teachers.Where(_ => _.Id == id).FirstOrDefault();
                GetStates(Teacher.Country);
                ViewBag.Bt = "Update";
                return View(Teacher);
            }
            else
            {
                ViewBag.BT = "Create";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(Teacher tea)
        {
            if (tea.Id == 0)
            {
                _context.Teachers.Add(tea);
            }
            else
            {
                _context.Entry(tea).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));//If Program.cs default routing Teacher Provide then Partial Pages routing works
        }

        public IActionResult Delete(int id)
        {
            var Employee = _context.Teachers.Find(id);
            _context.Teachers.Remove(Employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
