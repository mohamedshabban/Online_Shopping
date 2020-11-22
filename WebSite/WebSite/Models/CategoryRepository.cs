using System.Collections.Generic;

namespace WebSite.Models
{
    //9
    public class CategoryRepository:ICategoryRepository
    {
        public IEnumerable<Category> AllCategories=>
            new List<Category>
            {
                new Category{CategoryId = 1,CategoryName = "Clothes",Description = "Clothes"},
                new Category{CategoryId = 2,CategoryName = "Food",Description = "Food"},
                new Category{CategoryId = 3,CategoryName = "Electronics",Description = "Electronics"}
            };
    }
}