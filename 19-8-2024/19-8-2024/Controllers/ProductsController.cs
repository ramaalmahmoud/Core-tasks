using _19_8_2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
