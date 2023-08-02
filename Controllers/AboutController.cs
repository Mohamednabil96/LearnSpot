using Microsoft.AspNetCore.Mvc;

namespace TaskDay2.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
