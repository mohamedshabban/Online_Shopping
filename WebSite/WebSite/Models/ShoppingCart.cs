using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebSite.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        private readonly AppDatabaseContext _appDatabaseContext;

        public ShoppingCart(AppDatabaseContext appDatabaseContext)
        {
            _appDatabaseContext = appDatabaseContext;
        }
        //check if i have active session cart id or create a new one
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = 
                services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;//access all collection of request in session

            var context = services.GetService<AppDatabaseContext>();
            //get cart id or create a new 
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem =
                    _appDatabaseContext.ShoppingCartItems.
                        SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId
                             && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _appDatabaseContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDatabaseContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                _appDatabaseContext.
                    ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId
                             && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDatabaseContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDatabaseContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            //if it's null
            //if (ShoppingCartItems == null)
            //    ShoppingCartItems = _appDatabaseContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
            //        .Include(s => s.Product)
            //        .ToList();
            //= 
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDatabaseContext.ShoppingCartItems.
                           Where(c => c.ShoppingCartId == ShoppingCartId).
                           Include(s => s.Product)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = 
                _appDatabaseContext
                .ShoppingCartItems
                .Where(sp => sp.ShoppingCartId == ShoppingCartId);

            _appDatabaseContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDatabaseContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            return _appDatabaseContext.
                ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
        }

    }
}