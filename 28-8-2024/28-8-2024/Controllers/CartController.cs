using _28_8_2024.DTO;
using _28_8_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _28_8_2024.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDbContext db;
        public CartController(MyDbContext myDb)
        {
            db = myDb;

        }
        [HttpGet("cart/GetCartItemsForUser/{userID}")]
        public IActionResult GetCartItemsForUser(int userID)
        {
          var user=db.Carts.FirstOrDefault(x=>x.UserId==userID);
            var cartItem = db.CartItems.Where(ci => ci.CartId == user.CartId).Select(
                x => new cartItemResponseDTO
                {
                    CartItemId = x.CartItemId,
                    CartId = x.CartId,
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
    }
}
