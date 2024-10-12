using Microsoft.AspNetCore.Mvc.Filters;

namespace VetPMS.API.Filters
{
    public class ClinicIdActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
            if (context.HttpContext.Request.Headers.TryGetValue("ClinicId", out var clinicIdHeader))
            {
                if (int.TryParse(clinicIdHeader, out var clinicId))
                {
                   
                    context.ActionArguments["clinicId"] = clinicId;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
