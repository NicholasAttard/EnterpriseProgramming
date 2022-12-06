using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ActionFilters
{
    public class FilePermissionAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //I will use this to check if the user ahd the username '...' to allow him in the DeleteItem
            //In the home assignment you need to check if the current loged in user has the rights to access/edit this file

            ItemsServices myService = (ItemsServices)context.HttpContext.RequestServices.GetService(typeof(ItemsServices));

            string id = (context.ActionArguments.ElementAt(0).Value).ToString();

            if (context.HttpContext.User.Identity.Name == null)
            {
                context.Result = new UnauthorizedResult();
                //context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "ErrorMessage", controller = "Home", message = "access Denied" }));
            }
            else 
            {
                string currentlyLoggedInUsername = context.HttpContext.User.Identity.Name;

                if (currentlyLoggedInUsername != "nicholasattard@gmail.com") 
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            
        }
    }
}