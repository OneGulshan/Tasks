using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

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
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    FirstName = dt.Rows[i]["FirstName"].ToString(),
                    LastName = dt.Rows[i]["LastName"].ToString(),
                    JobRole = dt.Rows[i]["JobRole"].ToString(),
                };
                employees.Add(employee);
            }
            return View(employees);
        }

        public IActionResult Create(int id)
        {
            if (id > 0)
            {
                ViewBag.BT = "Update";
                SqlConnection con = new(_configuration.GetConnectionString("Con"));
                SqlCommand cmd = new("select * from Employee where Id ='" + id + "'", con);
                DataTable dt = new();
                SqlDataAdapter da = new(cmd);
                da.Fill(dt);
                Employee e = new()
                {
                    FirstName = dt.Rows[0]["FirstName"].ToString(),
                    LastName = dt.Rows[0]["LastName"].ToString(),
                    JobRole = dt.Rows[0]["JobRole"].ToString()
                };
                return View(e);
            }
            ViewBag.BT = "Save";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            SqlConnection con = new(_configuration.GetConnectionString("Con"));
            SqlCommand cmd = new("Insert into Employee('FirstName','LastName','JobRole') value('" + employee.FirstName + "','" + employee.LastName + "','" + employee.JobRole + "')", con);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            SqlConnection con = new(_configuration.GetConnectionString("Con"));
            con.Open();
            SqlCommand cmd = new("delete from Employee where Id ='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }
    }
}
