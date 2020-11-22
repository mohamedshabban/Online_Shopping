using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class ProductController : Controller
    {
        //now we can access model classes in controller
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;


        //need access to repository
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        //Get //Controller
        //public ViewResult List()
        //{
        //    var productListViewModel=new ProductsListViewModel();
        //    productListViewModel.Products = _productRepository.AllProducts;
        //    productListViewModel.CurrentCategory= "Hello";
        //    //to send more data by ViewBag Dynamic
        //    ViewBag.Message = "Hello from ViewResult List()";//available in my view
        //    //send to view
        //    //return View(_productRepository.AllProducts);
        //    return View(productListViewModel);
        //}
        public ViewResult List(string category)
        {
            var productViewModel=new ProductsListViewModel();
            if (string.IsNullOrEmpty(category))
            {
               productViewModel.Products= _productRepository.AllProducts.OrderBy(p => p.ProductId);
                productViewModel.CurrentCategory = "All Products";
            }
            else
            {
                productViewModel.Products = _productRepository.AllProducts.
                    Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.ProductId);
                productViewModel.CurrentCategory = _categoryRepository.AllCategories.
                    FirstOrDefault(c => c.CategoryName==category)?.CategoryName;
            }

            return View(productViewModel);
        }

        public IActionResult Details(int productId)
        {
            var product = _productRepository.GetProductById(productId: productId);
            if (product == null)
                return NotFound();
            return View(product);
        }

    }
}
