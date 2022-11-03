using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoapp.entity;

namespace Teknoapp.data.Abstract
{
    public interface IProductRepository:IRepository<ProductEntity>
    {
        ProductEntity GetProductDetails(string url);
        ProductEntity GetByIdWithCategories(int id);
        List<ProductEntity> GetProductsByCategory(string name,int page,int pageSize);
        List<ProductEntity> GetSearchResult(string searchString);
        List<ProductEntity> GetHomePageProducts();
        int GetCountByCategory(string category);
        void Update(ProductEntity entity, int[] categoryId);
    }
}
