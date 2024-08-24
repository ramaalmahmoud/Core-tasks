using _21_8_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21_8_2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly MyDbContext db;
        public OrdersController(MyDbContext context)
        {
            db = context;
        }



        [HttpGet]

        public IActionResult getAllOrders()
        {
            var order = db.Orders.ToList();
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
        [HttpGet("order/GetOrderById")]

        public IActionResult GetOrderById([FromQuery] int id)
        {
            var order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            if (id <= 0)
            {
                return BadRequest();
            }
            return Ok(order);
        }
        [HttpGet("order/GetOrderByName")]

        public IActionResult GetOrderByName([FromQuery] string date)
        {
            var order = db.Orders.Where(x => x.OrderDate == date).ToList();
            if (order == null)
            {
                return NotFound();
            }
            if (date == null)
            {
                return BadRequest();
            }
            return Ok(order);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            if (id <= 0)
            {
                return BadRequest();
            }
            db.Orders.Remove(order);
            db.SaveChanges();
            return NoContent();
        }
    }
}
