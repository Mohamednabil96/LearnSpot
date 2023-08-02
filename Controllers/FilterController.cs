using Microsoft.AspNetCore.Mvc;
using TaskDay2.Filters;

namespace TaskDay2.Controllers
{
    [HandleError]
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Some Exception Happens");
            return View();
        }

        public IActionResult Index2()
        {
            throw new Exception("Some Exception Happens");
            return View();
        }
    }
}
