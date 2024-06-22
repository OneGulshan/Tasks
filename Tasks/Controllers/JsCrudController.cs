using Microsoft.AspNetCore.Mvc;

namespace Tasks.Controllers
{
    public class JsCrudController : Controller
    {
        public IActionResult Index() => View();
    }
}
