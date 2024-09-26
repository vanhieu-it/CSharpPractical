using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptimizedEFCoreApp.Models;

namespace OptimizedEFCoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy danh sách đơn hàng cùng với dữ liệu liên quan (Eager Loading)
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _dbContext.Orders
                .Include(o => o.Customer)  // Eager loading Customer
                .Include(o => o.Products)  // Eager loading Products
                .AsNoTracking()
                .ToList();

            return Ok(orders);
        }

        // Lấy danh sách đơn hàng bằng Raw SQL
        [HttpGet("raw-sql")]
        public IActionResult GetOrdersRaw(int customerId)
        {
            var orders = _dbContext.Orders
                .FromSqlRaw("SELECT * FROM Orders WHERE CustomerId = {0}", customerId)
                .ToList();

            return Ok(orders);
        }

        // Giao dịch khi thêm đơn hàng
        [HttpPost("transaction")]
        public IActionResult ProcessOrder([FromBody] Order order)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                transaction.Commit();  // Commit transaction
            }

            return Ok();
        }
    }
}
