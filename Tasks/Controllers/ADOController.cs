using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Tasks.Controllers
{
    public class ADOController(IConfiguration configuration) : Controller
    {
        private readonly IConfiguration _configuration = configuration;

        public IActionResult Index()
        {
            List<Employee> employees = [];
            DataTable dt = new();
            SqlConnection con = new(_configuration.GetConnectionString("Con"));
            SqlCommand cmd = new("select * from Employees", con);
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
            Employee e = new();
            if (id > 0)
            {
                ViewBag.BT = "Update";
                SqlConnection con = new(_configuration.GetConnectionString("Con"));
                SqlCommand cmd = new("select * from Employees where Id ='" + id + "'", con);
                DataTable dt = new();
                SqlDataAdapter da = new(cmd);
                da.Fill(dt);
                e.FirstName = dt.Rows[0]["FirstName"].ToString();
                e.LastName = dt.Rows[0]["LastName"].ToString();
                e.JobRole = dt.Rows[0]["JobRole"].ToString();
                return View(e);
            }
            ViewBag.BT = "Save";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            SqlConnection con = new(_configuration.GetConnectionString("Con"));
            con.Open();
            if (employee.Id > 0)
            {
                SqlCommand cmd = new("Update Employees set FirstName = '" + employee.FirstName + "', LastName = '" + employee.LastName + "', JobRole = '" + employee.JobRole + "' where Id ='" + employee.Id + "'", con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new("Insert into Employees values ('" + employee.FirstName + "','" + employee.LastName + "','" + employee.JobRole + "')", con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            SqlConnection con = new(_configuration.GetConnectionString("Con"));
            con.Open();
            SqlCommand cmd = new("delete from Employees where Id ='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }
    }
}
