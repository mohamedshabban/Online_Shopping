using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    [Authorize]//to allow user log in before access this controller
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(
        IOrderRepository orderRepository,
            ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("","Your Cart is Empty!");
            }
            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }

            return View(order);
        }

        public IActionResult CheckOutComplete()
        {
            ViewBag.Message = "Congratulation";
            return View();
        }
    }
}
