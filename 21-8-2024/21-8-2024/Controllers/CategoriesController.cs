using _21_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21_8_2024.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly MyDbContext db;
        public CategoriesController(MyDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("category/getAllCategories")]
        public IActionResult getAllCategories()
        {
            var cat = db.Categories.ToList();
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }
        [HttpGet]
        [Route("category/GetCategoryById/{id:min(5)}")]
        public IActionResult GetCategoryById(int id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.Id == id);

            if (id <= 0)
            {
                return BadRequest();
            }
            if (cat == null) { 
            
                return NotFound();
            }

            return Ok(cat);
        }
        [HttpGet]
        [Route("category/GetCategoryByName/{name}")]
        public IActionResult GetCategoryByName(string name)
        {
            var cat = db.Categories.FirstOrDefault(x => x.Name == name);
            if (cat == null) { 
            return NotFound();
            }
            if (name == null)
            {
                return BadRequest();
            }
            return Ok(cat);
        }
        [HttpDelete]
        [Route("category/DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.Id == id);
            if (cat == null) {
                return NotFound();
            }

            if (id <= 0)
            {
                return BadRequest();
            }
            db.Categories.Remove(cat);
            db.SaveChanges();
            return NoContent();
        }


    }
}
