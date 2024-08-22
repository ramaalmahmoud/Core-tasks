using _19_8_2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _19_8_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext db;
        public ProductsController(MyDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(db.Products.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var category = db.Products.FirstOrDefault(x => x.Id == id);
            return Ok(category);

        }
        [HttpGet("{id1}/{price}")]
        public IActionResult GetProductcat(int id1,int price)
        {
            var category = db.Products.Where(c=>c.CategoryId==id1 && c.Price>price  ).Count();
            return Ok(category);

        }
        [HttpDelete("{id}")]

        public IActionResult deleteCProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var p = db.Products.FirstOrDefault(p => p.Id == id);

            if (p == null)
            {
                return NotFound();
            }
            db.Products.Remove(p);
            db.SaveChanges();
            return NoContent();

        }

        [HttpGet("api/product/{id:int}")]
        [HttpGet("api/product/{name}")]
        public IActionResult getByname(int id,string? name) 
        {
            if (id > 0) {
                var p = db.Products.FirstOrDefault(p => p.Id == id);
                return Ok(p);

            }
            if (!string.IsNullOrEmpty(name)) {
                var p2 = db.Products.FirstOrDefault(p => p.ProductName == name);
                return Ok(p2);
            }

          

           
            return NotFound();
        
        }
    }
}
