using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Tasks.Controllers
{
    public class EmployeeAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<DataAccessLayer.Models.Employee> employees = [];
            HttpClient client = new()//HttpClient for connecting with api
            {
                BaseAddress = new Uri("http://localhost:5171/")
            };
            HttpResponseMessage response = await client.GetAsync("api/employee");
            if (response.IsSuccessStatusCode)//IsSuccessStatusCode means response = 200(means query execured successfully) checked by throw postman
            {
                employees = JsonConvert.DeserializeObject<List<DataAccessLayer.Models.Employee>>(response.Content.ReadAsStringAsync().Result); //list of data me convert karne ke liye Json Formate ka use kar liya
            }
            return View(employees);
        }

        public async Task<IActionResult> Details(int Id)
        {
            return View(await GetEmployeeByID(Id));
        }

        private static async Task<DataAccessLayer.Models.Employee> GetEmployeeByID(int Id)
        {
            DataAccessLayer.Models.Employee employees = new();
            HttpClient client = new()
            {
                BaseAddress = new Uri("http://localhost:5171/")
            };
            HttpResponseMessage response = await client.GetAsync($"api/employee/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<DataAccessLayer.Models.Employee>(results);
            }
            return employees;
        }

        public async Task<IActionResult> Delete(int Id)
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri("http://localhost:5171/")
            };
            HttpResponseMessage response = await client.DeleteAsync($"api/employee/{Id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DataAccessLayer.Models.Employee employee)
        {
            HttpClient client = new() //BaseAddress prop ko Uri ke throw Api url bata dia jo hamein automatically Api se connect karwaegi
            {
                BaseAddress = new Uri("http://localhost:5171/")
            };
            var response = await client.PostAsJsonAsync("api/employee", employee);//replace HttpResponseMessage use always var because we don't know which type of we got
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.BT = "Update";
            return View(await GetEmployeeByID(Id));
        }

        [HttpPost]//Api ke ander hamare pass Put and Delete dono hai isliye edit ka put ke liye alag se method banana pada
        public async Task<IActionResult> Edit(DataAccessLayer.Models.Employee employee)
        {
            HttpClient client = new()//same code of create post
            {
                BaseAddress = new Uri("http://localhost:5171/") //BaseAddress prop ko Uri ke throw Api url bata dia jo hamein automatically Api se connect karwaegi
            };
            var response = await client.PutAsJsonAsync($"api/employee/{employee.Id}", employee);//replace HttpResponseMessage use always var because we don't know which type of we got
            if (response.IsSuccessStatusCode)
            {
                ViewBag.BT = "Update";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
