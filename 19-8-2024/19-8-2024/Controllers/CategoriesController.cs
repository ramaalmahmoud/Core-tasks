using _19_8_2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _19_8_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext db;
        public CategoriesController(MyDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(db.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == id);
            return Ok(category);

        }
    }
}
