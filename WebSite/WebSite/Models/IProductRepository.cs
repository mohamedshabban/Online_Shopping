using System.Collections.Generic;

namespace WebSite.Models
{
    //6
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product>ProductsOfTheWeek { get; }
        Product GetProductById(int productId);
    }
}