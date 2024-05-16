using System;
using System.Collections.Generic;
using System.Linq;

public class Rating
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public double Score { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<int, Dictionary<int, double>> userRatings = new Dictionary<int, Dictionary<int, double>>();

        // Thêm đánh giá
        void AddRating(int userId, int productId, double score)
        {
            if (!userRatings.ContainsKey(userId))
            {
                userRatings[userId] = new Dictionary<int, double>();
            }
            userRatings[userId][productId] = score;
        }

        // Tạo một số đánh giá mẫu
        AddRating(1, 101, 4.5);
        AddRating(1, 102, 3.0);
        AddRating(2, 101, 5.0);
        AddRating(2, 103, 4.0);
        AddRating(3, 102, 2.5);
        AddRating(3, 103, 4.5);

        // Tìm sản phẩm được đánh giá cao nhất bởi người dùng
        int userIdToQuery = 1;
        if (userRatings.ContainsKey(userIdToQuery))
        {
            var topProduct = userRatings[userIdToQuery].OrderByDescending(r => r.Value).FirstOrDefault();
            Console.WriteLine($"User {userIdToQuery} highest rated product: {topProduct.Key} with score {topProduct.Value}");
        }

        // Đề xuất sản phẩm cho người dùng dựa trên sản phẩm mà người khác đã đánh giá cao
        int userIdToRecommend = 1;
        var recommendedProducts = userRatings.Values
                                              .Where(r => r.Keys.Any(p => !userRatings[userIdToRecommend].ContainsKey(p)))
                                              .SelectMany(r => r)
                                              .GroupBy(r => r.Key)
                                              .OrderByDescending(g => g.Average(r => r.Value))
                                              .Take(3);

        Console.WriteLine($"Recommended products for user {userIdToRecommend}:");
        foreach (var product in recommendedProducts)
        {
            Console.WriteLine($"Product {product.Key} with average score {product.Average(r => r.Value)}");
        }
    }
}
