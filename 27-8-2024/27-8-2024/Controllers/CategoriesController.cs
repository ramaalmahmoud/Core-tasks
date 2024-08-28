using _27_8_2024.DTO;
using _27_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _27_8_2024.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly MyDbContext db;
        public CategoriesController(MyDbContext _db)
        {
            db = _db;
        }

        [HttpGet("category/getallCategories")]
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
        [HttpGet("{name}")]
        public IActionResult GetCategorybyName(string name)
        {
            var category = db.Categories.FirstOrDefault(x => x.Name == name);
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
        [HttpPost]
        [Route("category/createCategory")]
        public IActionResult createCategory([FromForm] categoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest();
            }
            if (categoryDTO.Image != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);

                }
                var filePath = Path.Combine(uploadsFolderPath, categoryDTO.Image.FileName);


            }


            var Category = new Category
            {
                Name = categoryDTO.Name,
                Image = categoryDTO.Image.FileName,
            };

            var createcategory = db.Categories.Add(Category);
            db.SaveChanges();
            if (createcategory == null)
            {
                return BadRequest();
            }
            return Ok(Category);
        }
        [HttpPut]
        [Route("category/editCategory{id}")]
        public IActionResult editCategory(int id, [FromForm] categoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest();
            }
            var existingcategory = db.Categories.FirstOrDefault(c => c.Id == id);
            if (existingcategory == null)
            {
                return NotFound();
            }
            if (categoryDTO.Image != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);

                }
                var filePath = Path.Combine(uploadsFolderPath, categoryDTO.Image.FileName);


            }


            existingcategory.Name = categoryDTO.Name ?? existingcategory.Name;
            existingcategory.Image = categoryDTO.Image.FileName ?? existingcategory.Image;



            var updatecategory = db.Categories.Update(existingcategory);
            db.SaveChanges();
            if (updatecategory == null)
            {
                return BadRequest();
            }
            return Ok(updatecategory);
        }





    }
}
