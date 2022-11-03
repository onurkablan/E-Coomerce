using Teknoapp.entity;

namespace Teknoapp.webui.Models
{
    public class ProductDetailModel
    {
        public ProductEntity Product { get; set; }
        public List<CategoryEntity> Categories { get; set; }
    }
}
