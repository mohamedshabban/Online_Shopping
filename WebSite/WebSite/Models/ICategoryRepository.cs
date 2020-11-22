using System.Collections.Generic;

namespace WebSite.Models
{
    //8
    public interface ICategoryRepository
    {
        IEnumerable<Category>AllCategories { get; }
    }
}