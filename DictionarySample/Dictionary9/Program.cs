using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<int, Product> products = new Dictionary<int, Product>
        {
            { 1, new Product { ProductId = 1, Name = "Laptop", Price = 999.99 } },
            { 2, new Product { ProductId = 2, Name = "Smartphone", Price = 599.99 } },
            { 3, new Product { ProductId = 3, Name = "Tablet", Price = 399.99 } },
            { 4, new Product { ProductId = 4, Name = "Smartwatch", Price = 199.99 } }
        };

        // Tìm sản phẩm có giá trên 500
        var expensiveProducts = products.Values.Where(p => p.Price > 500);

        Console.WriteLine("Products with price above 500:");
        foreach (var product in expensiveProducts)
        {
            Console.WriteLine($"ProductId: {product.ProductId}, Name: {product.Name}, Price: {product.Price}");
        }

        // Tìm sản phẩm dựa trên từ khóa trong tên
        var keyword = "Smart";
        var keywordProducts = products.Values.Where(p => p.Name.Contains(keyword));

        Console.WriteLine($"\nProducts containing '{keyword}' in their name:");
        foreach (var product in keywordProducts)
        {
            Console.WriteLine($"ProductId: {product.ProductId}, Name: {product.Name}, Price: {product.Price}");
        }
    }
}
