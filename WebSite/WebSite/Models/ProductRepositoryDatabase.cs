using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebSite.Models
{
    public class ProductRepositoryDatabase:IProductRepository
    {
        private readonly AppDatabaseContext _appDatabaseContext;

        public ProductRepositoryDatabase(AppDatabaseContext appDatabaseContext)
        {
            _appDatabaseContext = appDatabaseContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _appDatabaseContext.Products.
                    Include(c => c.Category);
            }
        }

        public IEnumerable<Product> ProductsOfTheWeek
        {
            get
            {
                return _appDatabaseContext.Products.
                    Include(c => c.Category).
                    Where(p => p.IsProductOfTheWeek);
            }
        }

        public Product GetProductById(int productId)
        {
            return _appDatabaseContext.Products.
                FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
