using lecture9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lecture9.Controllers
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
        [Authorize]
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
        [HttpGet]
        [Route("product/getAllProductsbyCategory/{categoryId}")]
        public IActionResult getAllProductsbyCategory(int categoryId)
        {
            var cat = db.Products.Where(x => x.CategoryId == categoryId).ToList();
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }
        [HttpGet]
        [Route("product/getProductsbyID/{id}")]
        public IActionResult getProductsbyID(int id)
        {
            var cat = db.Products.Where(x => x.Id == id).ToList();
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }
    }
}
