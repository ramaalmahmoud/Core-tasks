using _26_8_2024.DTO;
using _26_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _26_8_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : Controller
    {
        private readonly MyDbContext db;
        public usersController(MyDbContext _db) {
            db = _db;
        }
        [HttpGet]
        public IActionResult geatAllUsers()
        {
            var users = db.Users.ToList();
            return Ok(users);
        }
        [HttpGet("user/getUserByID{id}")]
        public IActionResult getUserByID(int id)
        {
            var user = db.Users.FirstOrDefault(x=>x.Id == id);
            return Ok(user);
        }
        [HttpGet("user/getUserByName{name}")]
        public IActionResult getUserByName(string name)
        {
            var user = db.Users.FirstOrDefault(x => x.Username== name);
            return Ok(user);
        }
        [HttpDelete("user/deleteUser{id}")]
        public IActionResult deleteUser(int id) { 
        var user = db.Users.FirstOrDefault(x=>x.Id==id);  
            db.Users.Remove(user);
            db.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult createUser([FromForm] userDTO userDTO)
        {
            var user = new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                Email = userDTO.Email,

            };
            db.Users.Add(user);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult updateUser(int id, [FromForm] userDTO userDTO) { 
        var user=db.Users.Find(id);
            user.Username = userDTO.Username ?? user.Username;
            user.Password = userDTO.Password ?? user.Password;
            user.Email = userDTO.Email?? user.Email;
            db.Users.Update(user);
            db.SaveChanges();
            return NoContent();

        }


    }
}
