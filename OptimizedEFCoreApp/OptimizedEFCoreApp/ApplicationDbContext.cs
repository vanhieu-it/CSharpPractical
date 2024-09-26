using Microsoft.EntityFrameworkCore;
using OptimizedEFCoreApp.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tạo index để tối ưu truy vấn
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .HasDatabaseName("Index_ProductName");

        // Global Query Filter để chỉ lấy các sản phẩm đang hoạt động
        modelBuilder.Entity<Product>().HasQueryFilter(p => p.IsActive);
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder
    //        .UseLazyLoadingProxies() // Bật Lazy Loading
    //        .LogTo(Console.WriteLine, LogLevel.Information);  // Log các truy vấn SQL
    //}
}
