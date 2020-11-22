using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;
namespace WebSite.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> ProductsOFTheWeek { get; set; }
    }
}
