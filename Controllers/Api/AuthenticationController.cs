using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockCRM.Models;
using MockCRM.Filters;
using Pomelo.EntityFrameworkCore.MySql.IntegrationTests;
namespace MockCRM.Controllers.Api
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private ApplicationDbContext _context;
        private IConfiguration _configuration;
        [HttpPost,Route("register")]
        public  ActionResult<string> Register([FromBody] User user)
        {
            //validation
            if (!ModelState.IsValid)
            {
                return Json(new { status = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
            }
            _context.User.Add(user);
            int rows =  _context.SaveChanges();
            return Json(new { status=true });
        }
        [HttpPost,Route("login")]
        public ActionResult<string> Login([FromBody] User user)
        {
            if (user.Authenticate(_context))
            {
                JsonWebToken jsonWebToken = new JsonWebToken(_context,_configuration);
                return Json(new {status=true,token = jsonWebToken.Create(user)});
            }
            return Json(new { status = false, errors = new { errorMessage = "Invalid Credentials" } });
        }
        [Route("user"),TypeFilter(typeof(ApiAuthentication))]
        public ActionResult<string> User(int user_id)
        {
            return Json(_context?.User.Find(user_id));
        }
        public AuthenticationController(ApplicationDbContext _context,IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;
        }

    }
 
}
