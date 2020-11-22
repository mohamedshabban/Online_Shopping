using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class ShoppingCartItem
    {
        //Counter
        public int ShoppingCartItemId { get; set; }
        //Amount of item added
        public int Amount { get; set; }
        //Product in Shopping Cart
        public Product Product { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
