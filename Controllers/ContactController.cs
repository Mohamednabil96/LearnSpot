using Microsoft.AspNetCore.Mvc;

namespace TaskDay2.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
