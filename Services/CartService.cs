using BlazorApp2.Models;

namespace BlazorApp2.Services;

public class CartService
{
    private readonly List<CartItem> _items = new();

    public IReadOnlyList<CartItem> Items => _items;

    public void AddToCart(Product product, int quantity = 1)
    {
        var existing = _items.FirstOrDefault(i => i.ProductId == product.Id);
        if (existing != null)
        {
            existing.Quantity += quantity;
        }
        else
        {
            _items.Add(new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Quantity = quantity
            });
        }
    }

    public void Remove(int productId)
    {
        var existing = _items.FirstOrDefault(i => i.ProductId == productId);
        if (existing != null) _items.Remove(existing);
    }

    public void Clear() => _items.Clear();

    public decimal Total() => _items.Sum(i => i.Total);

    public int Count() => _items.Sum(i => i.Quantity);
}
