using OptimizedEFCoreApp.Models;

namespace OptimizedEFCoreApp
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Kiểm tra nếu cơ sở dữ liệu đã có dữ liệu
            if (context.Products.Any()) return;

            var customers = new List<Customer>
        {
            new Customer { Name = "Customer 1" },
            new Customer { Name = "Customer 2" }
        };

            var products = new List<Product>
        {
            new Product { Name = "Product 1", Price = 10, IsActive = true },
            new Product { Name = "Product 2", Price = 20, IsActive = true },
            new Product { Name = "Product 3", Price = 30, IsActive = false }
        };

            var orders = new List<Order>
        {
            new Order { OrderDate = DateTime.Now, Customer = customers[0], Products = new List<Product> { products[0], products[1] } },
            new Order { OrderDate = DateTime.Now, Customer = customers[1], Products = new List<Product> { products[1], products[2] } }
        };

            context.Customers.AddRange(customers);
            context.Products.AddRange(products);
            context.Orders.AddRange(orders);

            context.SaveChanges();
        }
    }

}
