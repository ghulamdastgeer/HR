using HR_DATA.HR_Module.UserMgt;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using HR_DATA.Repository;

namespace HR.API.Helper
{
    public class LogUserActivity : IAsyncActionFilter
    {
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ResultContext = await next();

            var UserId = int.Parse(ResultContext.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value);

            var _repo = ResultContext.HttpContext.RequestServices.GetService<IUserRepository>();
            var user = await _repo.Get(UserId);
            user.LastActive = DateTime.Now;
            await _repo.SaveAll();
        }
    }
}
