using ServerLibrary.Models;

namespace ServerLibrary.Repositories;

public class ProductRepository : Repository<Product, int>
{
    public ProductRepository(ManagementdbContext context) : base(context)
    {
    }

    public Product? GetByName(string productName)
    {
        return _context.Products.SingleOrDefault(p => p.ProductName.Contains(productName));
    }
}
