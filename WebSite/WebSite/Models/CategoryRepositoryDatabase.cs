using System.Collections.Generic;

namespace WebSite.Models
{
    public class CategoryRepositoryDatabase:ICategoryRepository
    {
        private readonly AppDatabaseContext _appDatabaseContext;

        public CategoryRepositoryDatabase(AppDatabaseContext appDatabaseContext)
        {
            _appDatabaseContext = appDatabaseContext;
        }
        public IEnumerable<Category> AllCategories => _appDatabaseContext.Categories;
         
    }
}