using System.Collections.Generic;

namespace stock_manager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        
    }
}