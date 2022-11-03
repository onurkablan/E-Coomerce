using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoapp.entity;

namespace Teknoapp.business.Abstract
{
    public interface IProductService
    {
        ProductEntity GetById(int id);
        
        ProductEntity GetProductDetails(string url);
        List<ProductEntity> GetProductsByCategory(string name, int page, int pageSize);

        List<ProductEntity> GetAll();
        List<ProductEntity> GetHomePageProducts();
        List<ProductEntity> GetSearchResult(string searchString);

        ProductEntity GetByIdWithCategories(int id);

        void Create(ProductEntity entity);
        void Update(ProductEntity entity);
        void Delete(ProductEntity entity);
        int GetCountByCategory(string category);
        void Update(ProductEntity entity, int[] categoryId);
    }
}
