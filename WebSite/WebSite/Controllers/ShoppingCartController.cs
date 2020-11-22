using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository,
                                      ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.
                                                GetShoppingCartItems();


            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };


            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var product = _productRepository.AllProducts.FirstOrDefault(
                p => p.ProductId == productId);
            if(product!=null)
                _shoppingCart.AddToCart(product,1);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var product = _productRepository.AllProducts.
                FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
                _shoppingCart.RemoveFromCart(product);
            return RedirectToAction("Index"); 
        }
    }
}
