using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskDay2.Filters
{
    public class HandleErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult result = new ViewResult();
            result.ViewName = "Error";
            context.Result = result;
        }
    }
}
