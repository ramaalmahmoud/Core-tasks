using _28_8_2024.DTO;
using _28_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _28_8_2024.Controllers
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

        }
    }

