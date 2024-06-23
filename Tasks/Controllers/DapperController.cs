using Dapper;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Tasks.Controllers
{
    public class DapperController : Controller
    {
        private readonly string Connection = "Data Source=DESKTOP-NCCJ25F;Initial Catalog=TasksDB;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=True";
        public IActionResult Index()
        {
            using SqlConnection connection = new(Connection);
            var logins = connection.Query<Login>("SELECT * FROM Logins");
            return View(logins);
        }

        public IActionResult Create(int id)
        {
            ViewBag.Bt = "Create";
            Login temp = new();
            if (id > 0)
            {
                ViewBag.Bt = "Update";
                using SqlConnection connection = new(Connection);
                var Params = new DynamicParameters();
                Params.Add("@Flag", "Edit");
                Params.Add("@Id", id);
                temp = connection.Query<Login>("LoginProcedure", Params, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                return View(temp);
            }
            else
            {
                return View(temp);
            }
        }

        [HttpPost]
        public IActionResult Create(Login m)
        {
            Login temp = new();
            using (SqlConnection connection = new(Connection))
            {
                var Params = new DynamicParameters();
                Params.Add("@Flag", "Check");
                Params.Add("@Id", m.Id);
                temp = connection.Query<Login>("LoginProcedure", Params, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                if (temp == null)
                {
                    string myCommond = "Insert into Logins values('" + m.Email + "', '" + m.Password + "');";
                    connection.Execute(myCommond);
                }
                else
                {
                    string myCommond = "Update Logins set email='" + m.Email + "', password='" + m.Password + "' where id='" + m.Id + "';";
                    connection.Execute(myCommond);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(Login m)
        {
            using (SqlConnection connection = new(Connection))
            {
                string myCommond = "Update Logins set email='" + m.Email + "', password='" + m.Password + "' where id='" + m.Id + "';";
                connection.Execute(myCommond);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Read()
        {
            List<Login> Temp = [];
            using (SqlConnection connection = new(Connection))
            {
                var Params = new DynamicParameters();
                Params.Add("@Flag", "Read");
                Temp = connection.Query<Login>("LoginProcedure", Params, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
            return Json(Temp);
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection connection = new(Connection))
            {
                var Params = new DynamicParameters();
                Params.Add("@Flag", "Delete");
                Params.Add("@Id", id);
                List<Login> Temp = connection.Query<Login>("LoginProcedure", Params, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
            return RedirectToAction("Index");
        }
    }
}
