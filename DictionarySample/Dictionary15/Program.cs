using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
    public string Customer { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<int, Order> orders = new Dictionary<int, Order>
        {
            { 1, new Order { OrderId = 1, OrderDate = DateTime.Parse("2024-01-01"), TotalAmount = 100, Customer = "Alice" } },
            { 2, new Order { OrderId = 2, OrderDate = DateTime.Parse("2024-02-15"), TotalAmount = 150, Customer = "Bob" } },
            { 3, new Order { OrderId = 3, OrderDate = DateTime.Parse("2024-01-20"), TotalAmount = 200, Customer = "Charlie" } },
            { 4, new Order { OrderId = 4, OrderDate = DateTime.Parse("2024-03-10"), TotalAmount = 250, Customer = "Alice" } }
        };

        // Tìm các đơn hàng của Alice có tổng số tiền lớn hơn 100 và sắp xếp theo ngày đặt hàng
        var aliceOrders = orders.Values
                                .Where(o => o.Customer == "Alice" && o.TotalAmount > 100)
                                .OrderBy(o => o.OrderDate);

        Console.WriteLine("Alice's orders with amount greater than 100:");
        foreach (var order in aliceOrders)
        {
            Console.WriteLine($"OrderId: {order.OrderId}, OrderDate: {order.OrderDate}, TotalAmount: {order.TotalAmount}");
        }
    }
}
