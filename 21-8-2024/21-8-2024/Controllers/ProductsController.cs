using _21_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21_8_2024.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext db;
        public ProductsController(MyDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("product/getAllProducts")]

        public IActionResult getAllProducts()
        {
            var product = db.Products.ToList();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("product/GetProductById{id:max(10)}")]

        public IActionResult GetProductById([FromQuery] int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            if (id <= 0)
            {
                return BadRequest();
            }
            return Ok(product);
        }
        [HttpGet("product/GetProductByName")]

        public IActionResult GetProductByName([FromQuery] string name)
        {
            var product = db.Products.FirstOrDefault(x => x.ProductName == name);
            if (product == null)
            {
                return NotFound();
            }
            if (name == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            if (id <= 0)
            {
                return BadRequest();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return NoContent();
        }
    }
}
