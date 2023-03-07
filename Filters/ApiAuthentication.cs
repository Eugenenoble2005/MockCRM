
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MockCRM.Models;
using Pomelo.EntityFrameworkCore.MySql.IntegrationTests;
using System.Text.Json;

namespace MockCRM.Filters
{
    public class ApiAuthentication : IActionFilter
    {
        private IConfiguration _configuration;
        private ApplicationDbContext _context;
        public ApiAuthentication(IConfiguration _configuration, ApplicationDbContext _context)
        {
            this._configuration = _configuration;
            this._context = _context;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string auth_token = context.HttpContext.Request.Headers["auth_token"];
            if(auth_token == null || auth_token == "")
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                try
                {
                    JsonWebToken jsonWebToken = new JsonWebToken(_context, _configuration);
                    string user_json = jsonWebToken.Verify(auth_token);
                    var user_data = JsonSerializer.Deserialize<User>(user_json);
                    Console.WriteLine(user_data.UserName);
                    context.ActionArguments["user_id"] = user_data.Id;
                }
                catch (Exception)
                {
                    context.Result = new UnauthorizedResult();
                }
            }

        }
      
    }
}
