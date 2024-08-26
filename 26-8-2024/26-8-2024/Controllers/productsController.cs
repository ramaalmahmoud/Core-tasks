using _26_8_2024.DTO;
using _26_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _26_8_2024.Controllers
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
            public IActionResult GetProductcat(int id1, int price)
            {
                var category = db.Products.Where(c => c.CategoryId == id1 && c.Price > price).Count();
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
            public IActionResult getByname(int id, string? name)
            {
                if (id > 0)
                {
                    var p = db.Products.FirstOrDefault(p => p.Id == id);
                    return Ok(p);

                }
                if (!string.IsNullOrEmpty(name))
                {
                    var p2 = db.Products.FirstOrDefault(p => p.ProductName == name);
                    return Ok(p2);
                }




                return NotFound();

            }
        [HttpPost]
        [Route("product/createProduct")]
        public IActionResult createProduct([FromForm] productDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest();
            }
            if (productDTO.ProductImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);

                }
                var filePath = Path.Combine(uploadsFolderPath, productDTO.ProductImage.FileName);


            }


            var product = new Product
            {
                ProductName = productDTO.ProductName,

                Description = productDTO.ProductImage.FileName,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId,
               


            };

            var createproduct = db.Products.Add(product);
            db.SaveChanges();
            if (createproduct == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }
        [HttpPut]
        [Route("product/editProduct{id}")]
        public IActionResult editProduct(int id, [FromForm] productDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest();
            }
            var existingproduct = db.Products.FirstOrDefault(c => c.Id == id);
            if (existingproduct == null)
            {
                return NotFound();
            }
            if (productDTO.ProductImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);

                }
                var filePath = Path.Combine(uploadsFolderPath, productDTO.ProductImage.FileName);


            }


            existingproduct.ProductName = productDTO.ProductName ?? existingproduct.ProductName;
            existingproduct.Description = productDTO.Description ?? existingproduct.Description;
            existingproduct.Price = productDTO.Price ?? existingproduct.Price;
            existingproduct.CategoryId = productDTO.CategoryId ?? existingproduct.CategoryId;
            existingproduct.ProductImage = productDTO.ProductImage.FileName ?? existingproduct.ProductImage;



            var updatecategory = db.Products.Update(existingproduct);
            db.SaveChanges();
            if (updatecategory == null)
            {
                return BadRequest();
            }
            return Ok(updatecategory);
        }

    }
}

