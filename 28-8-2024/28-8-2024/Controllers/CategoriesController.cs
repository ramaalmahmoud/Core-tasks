using _28_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _28_8_2024.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly MyDbContext db;
        public CategoriesController(MyDbContext context)
        {
            db = context;
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
        [HttpDelete("category/deletecategory/{id}")]
        public IActionResult Delete(int id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.Id == id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return NoContent();
        }
    }
}
