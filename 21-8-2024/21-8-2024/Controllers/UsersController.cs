using _21_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21_8_2024.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext db;
        public UsersController(MyDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("user/getAllUsers")]
        public IActionResult getAllUsers()
        {
            var user = db.Users.ToList();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        [Route("user/GetUserById/{id}")]
        public IActionResult GetUserById( int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            if (id <= 0)
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [HttpGet]
        [Route("user/GetUserByName/{name}")]
        public IActionResult GetUserByName(string name)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == name);
            if (user == null)
            {
                return NotFound();
            }
            if (name == null) { 
            return BadRequest();
            }
            return Ok(user);
        }
        [HttpDelete]
        [Route("user/DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            if (id <= 0)
            {
                return BadRequest();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return NoContent();
        }
    }
}
