namespace leetcode.TestingThings.LINQPerf;

public class ProductGenerator
{
    public static List<Product> GenerateProducts(int count)
    {
        return Enumerable.Range(0, count)
            .Select(i => new Product { Id = i, Name = $"Product {i}", Price = i * 10 })
            .ToList();
    }
}