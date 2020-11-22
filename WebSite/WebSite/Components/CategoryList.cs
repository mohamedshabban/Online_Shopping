using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Components
{
    public class CategoryList:ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryList(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryRepository.AllCategories.OrderBy(c => c.CategoryName));
        }
    }
}
