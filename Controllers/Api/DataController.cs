using Microsoft.AspNetCore.Mvc;
using MockCRM.Filters;
using MockCRM.Models;
using Pomelo.EntityFrameworkCore.MySql.IntegrationTests;

namespace MockCRM.Controllers.Api
{
    [Route("api/data")]
    public class DataController : Controller
    {
        private ApplicationDbContext _context;

        [HttpPost,Route("store")]
        [TypeFilter(typeof(ApiAuthentication))]
        public ActionResult<string> Store([FromBody] Data data, int user_id)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
            }
            var user = _context.User.Find(user_id);
            data.UserId = user_id;
            _context.Data.Add(data);
            _context.SaveChanges();
            return Json(new { status = true });
        }
        public DataController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        [Route(""),TypeFilter(typeof(ApiAuthentication))]
        public ActionResult<string> Index(int user_id)
        {
            return Json(_context.Data.Where((d=>d.UserId == user_id)).ToList());
        }
    }
}
