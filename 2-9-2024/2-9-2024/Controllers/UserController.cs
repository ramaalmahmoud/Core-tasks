using _2_9_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2_9_2024.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _db;
        public UserController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet("get/getUserByEmail{email}")]
        public IActionResult getUserByEmail(string email)
        {
            var user=_db.Users.FirstOrDefault(x => x.Email == email);
            return Ok(user);
        }
        [HttpPost("register")]
        public ActionResult Register([FromForm] UserDTO model)
        {
            if (model.Password != model.repeatePassword)
            {
                return BadRequest();
            }
            var existingUser = _db.Users.FirstOrDefault(x => x.Email == model.Email);
            if (existingUser != null)
            {
                return BadRequest("this email is already exist");
            }
            byte[] passwordHash, passwordSalt;
            PasswordHasher.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Username = model.UserName,
                Email = model.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _db.Users.Add(user);
            _db.SaveChanges();

            return Ok(user);
        }
        [HttpPost("login")]
        public IActionResult Login([FromForm] loginUserDTO model)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null || !PasswordHasher.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }
            // Generate a token or return a success response
            return Ok("User logged in successfully");
        }
    }
}
