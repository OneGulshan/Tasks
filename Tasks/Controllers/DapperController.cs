using Tasks.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Tasks.Controllers
{
    public class DapperController : Controller
    {
        string Connection = "Data Source=DESKTOP-MF3G10C;Initial Catalog=TasksDB;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=True";
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Create(Login m)
        {
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                string myCommond = "Insert into Login values('" + m.Id + "','" + m.Email + "', '" + m.Password + "');";
                connection.Execute(myCommond);
            }
            return Json("");
        }

        public IActionResult Update(Login m)
        {
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                string myCommond = "Update Login set id='" + m.Id + "', email='" + m.Email + "', password='" + m.Password + "';";
                connection.Execute(myCommond);
            }
            return Json("");
        }

        public IActionResult Read()
        {
            List<Login> Temp = new List<Login>();
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                var Params = new DynamicParameters();
                Params.Add("@Flag", "Read");
                Temp = connection.Query<Login>("LoginProcedure", Params, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
            return Json(Temp);
        }

        public IActionResult Delete()
        {
            List<Login> Temp = new List<Login>();
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                var Params = new DynamicParameters();
                Params.Add("@Flag", "Delete");
                Temp = connection.Query<Login>("LoginProcedure", Params, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
            return Json(Temp);
        }
    }
}
