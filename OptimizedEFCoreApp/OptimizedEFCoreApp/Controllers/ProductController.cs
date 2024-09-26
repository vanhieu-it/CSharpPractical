using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptimizedEFCoreApp.Models;

namespace OptimizedEFCoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy sản phẩm với Projection (tối ưu dữ liệu trả về)
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _dbContext.Products
                .Where(p => p.IsActive)
                .Select(p => new { p.Name, p.Price })  // Projection
                .AsNoTracking()  // Truy vấn chỉ đọc
                .ToList();

            return Ok(products);
        }

        // Thêm sản phẩm với Bulk Insert
        [HttpPost("bulk-insert")]
        public IActionResult BulkInsertProducts([FromBody] List<Product> products)
        {
            _dbContext.BulkInsert(products);  // Sử dụng Bulk Insert
            return Ok();
        }
    }
}
