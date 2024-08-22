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
        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == id);
            return Ok(category);

        }
        [HttpDelete("{id}")]

        public IActionResult deleteCategory(int id)
        {
            var category = db.Categories.FirstOrDefault(p => p.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return NoContent();

        }

        [ HttpGet("{name:alpha}")]
        public IActionResult GetCategorybyName(string name)
        {
            var category = db.Categories.FirstOrDefault(x => x.Name == name);
            return Ok(category);

        }
        //[HttpGet("search")]
        //public IEnumerable<Product> SearchProducts([FromQuery] string name)
        //{
        //    var c= db.Categories.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        //    return Ok(c);
        //}
    }
}
