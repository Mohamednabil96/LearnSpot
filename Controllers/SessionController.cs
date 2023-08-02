using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TaskDay2.Controllers
{
    public class SessionController : Controller
    {
        [Route("setSession")]
        public IActionResult SetSession(string name, int age)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);

            return Content("Session Set");

            //     /setSession?name=mohamed&age=27
        }

        [Route("getSession")]
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            if (name != null && age.HasValue)
            {
                return Content($"My Name is {name}, My Age is {age}");
            }
            return Content("Session not set");

            //    /getSession
        }
    }
}
