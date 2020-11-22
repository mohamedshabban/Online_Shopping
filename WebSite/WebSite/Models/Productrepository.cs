using System.Collections.Generic;
using System.Linq;

namespace WebSite.Models
{
    //6
    public class Productrepository:IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository=new CategoryRepository(); 

        public IEnumerable<Product> AllProducts=>new List<Product>
        {
            new Product
            {
                ProductId = 1,Name = "Jacket",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",Price = 400M,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61fTX5TjAEL._UL1001_.jpg",ImageThumbnailUrl = "",IsProductOfTheWeek = true,InStock = true,
                CategoryId = 1,Category = _categoryRepository.AllCategories.ToList()[0]
            },
            new Product
            {
            ProductId = 2,Name = "Mango",ShortDescription = "Mango" ,LongDescription = "Mango is the base of Fruits",
            AllergyInformation = "",Price = 10M,
            ImageUrl = "https://www.supermarketperimeter.com/ext/resources/0722-mangoes.jpg?1595428736",ImageThumbnailUrl = "",IsProductOfTheWeek = true,InStock = true,
            CategoryId = 2,Category = _categoryRepository.AllCategories.ToList()[1]
             },
            new Product
            {
                ProductId = 3,Name = "Freezer",ShortDescription = "Freezer" ,LongDescription = "Freezer is the base of Electronics",
                AllergyInformation = "",Price = 1500M,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/619cPmKZsKL._AC_SL1500_.jpg",ImageThumbnailUrl = "",IsProductOfTheWeek = true,InStock = true,
                CategoryId = 3,Category = _categoryRepository.AllCategories.ToList()[2]
            }

        };
        public IEnumerable<Product> ProductsOfTheWeek { get; }
        public Product GetProductById(int productId)
        {
            return AllProducts.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}