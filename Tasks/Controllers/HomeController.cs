using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace Tasks.Controllers
{
    public class HomeController(IHtmlLocalizer<HomeController> localizer) : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _localizer = localizer;
        public IActionResult Index() => View(ViewData["Welcome"] = _localizer["Welcome"]);
    }
}
