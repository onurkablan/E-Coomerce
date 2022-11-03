using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoapp.business.Abstract;
using Teknoapp.data.Abstract;
using Teknoapp.entity;

namespace Teknoapp.business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(CategoryEntity entity)
        {
             _categoryRepository.Create(entity);

        }

        public void Delete(CategoryEntity entity)
        {
             _categoryRepository.Delete(entity);

        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            _categoryRepository.DeleteFromCategory(productId, categoryId);
        }

        public List<CategoryEntity> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public CategoryEntity GetById(int id)
        {
            return _categoryRepository.GetById(id);

        }

        public CategoryEntity GetByIdWithProducts(int categoryId)
        {
            return _categoryRepository.GetByIdWithProducts(categoryId);
        }

        public void Update(CategoryEntity entity)
        {
            _categoryRepository.Update(entity);

        }

        public bool Validation(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
