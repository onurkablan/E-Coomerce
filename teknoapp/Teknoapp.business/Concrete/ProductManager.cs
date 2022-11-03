using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoapp.business.Abstract;
using Teknoapp.entity;

using Teknoapp.data.Abstract;

namespace Teknoapp.business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(ProductEntity entity)
        {
                _productRepository.Create(entity);
     
        }

        public void Delete(ProductEntity entity)
        {
            _productRepository.Delete(entity);
        }

        public List<ProductEntity> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ProductEntity GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public ProductEntity GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<ProductEntity> GetHomePageProducts()
        {
            return _productRepository.GetHomePageProducts();
        }

        public ProductEntity GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<ProductEntity> GetProductsByCategory(string name, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(name,page,pageSize);

        }

        public List<ProductEntity> GetSearchResult(string searchString)
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(ProductEntity entity)
        {

            _productRepository.Update(entity);
        }

        public void Update(ProductEntity entity, int[] categoryId)
        {
            _productRepository.Update(entity,categoryId);
        }
       
    }
}
