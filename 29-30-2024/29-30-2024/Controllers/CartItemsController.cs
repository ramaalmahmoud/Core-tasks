using _29_30_2024.DTO;
using _29_30_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _29_30_2024.Controllers
{
    public class CartItemsController : Controller
    {
        private readonly MyDbContext db;
        public CartItemsController(MyDbContext myDb)
        {
            db = myDb;

        }
        [HttpGet("cartitem")]
        public IActionResult getCartItems()
        {
            var cartItem = db.CartItems.Select(x => new cartItemResponseDTO
            {
                CartId = x.CartId,
                CartItemId = x.CartItemId,
                Quantity = x.Quantity,
                Product = new productDTO
                {
                    Id = x.Product.Id,
                    ProductName = x.Product.ProductName,
                    Price = x.Product.Price,

                }

            });

            return Ok(cartItem);
        }




        [HttpPost("addtocart")]
        public IActionResult addCartItem([FromBody] addCartItemRequestDTO cart)
        {
            var data = new CartItem
            {
                CartId = cart.CartId,
                Quantity = cart.Quantity,
                ProductId = cart.ProductId,

            };
            db.CartItems.Add(data);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut("update/updateCart/{id}")]
        public IActionResult updateCart(int id,[FromBody] cartItemsDTO cart)
        {
            var cartItem = db.CartItems.FirstOrDefault(ci => ci.CartItemId == id);

            if (cartItem == null)
            {
                return BadRequest();
            }
            
           
             cartItem.Quantity=cart.Quantity;

            



            var updatecItems = db.CartItems.Update(cartItem);
            db.SaveChanges();
            if (updatecItems == null)
            {
                return BadRequest();
            }
            return Ok(updatecItems);
        }

        [HttpDelete("delete/deleteItem/{id}")]

        public IActionResult deleteItem(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var cartItem = db.CartItems.FirstOrDefault(ci => ci.CartItemId == id);

            if (cartItem == null)
            {
                return NotFound();
            }
            db.CartItems.Remove(cartItem);
            db.SaveChanges();
            return NoContent();

        }

    }
}
