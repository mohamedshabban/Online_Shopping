using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            _shoppingCart.ShoppingCartItems =
                _shoppingCart.GetShoppingCartItems();
            var ShoppingCartViewModel=new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(ShoppingCartViewModel);
        }
    }
}
