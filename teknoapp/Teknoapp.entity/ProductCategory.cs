using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Teknoapp.entity
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
