using BlazorApp2.Models;

namespace BlazorApp2.Services;

public class ProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        // Seed sample products
        _products = new List<Product>();
        for (int i = 1; i <= 30; i++)
        {
            _products.Add(new Product
            {
                Id = i,
                Name = $"Product {i}",
                Description = $"Description for product {i}.",
                Price = 9.99m + i,
                ImageUrl = "https://via.placeholder.com/300x200?text=Product+" + i
            });
        }
    }

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
}
