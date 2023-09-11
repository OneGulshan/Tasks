using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class ADOController : Controller
    {
        private readonly IConfiguration _configuration;
        public ADOController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            List<Employee> employees = new();
            DataTable dt = new();
            SqlConnection con = new(_configuration.GetConnectionString("Con"));
            SqlCommand cmd = new("select * from Employee", con);
            SqlDataAdapter da = new(cmd);
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Employee employee = new()
                {
                    FirstName = dt.Rows[i]["FirstName"].ToString(),
                    LastName = dt.Rows[i]["LastName"].ToString(),
                    JobRole = dt.Rows[i]["JobRole"].ToString(),
                };
                employees.Add(employee);
            }
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            SqlConnection con = new(_configuration.GetConnectionString("Con"));
            SqlCommand cmd = new("Insert into Employee('FirstName','LastName','JobRole') values('" + employee.FirstName + "','" + employee.LastName + "','" + employee.JobRole + "')", con);
            return RedirectToAction(nameof(Index));
        }
    }
}
