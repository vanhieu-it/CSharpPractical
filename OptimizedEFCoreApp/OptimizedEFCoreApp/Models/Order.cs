namespace OptimizedEFCoreApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Customer Customer { get; set; }  // Lazy loading Customer
        public virtual List<Product> Products { get; set; } = new List<Product>(); // Lazy loading Products
    }

}
