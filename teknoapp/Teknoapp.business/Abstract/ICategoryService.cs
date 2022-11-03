using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoapp.entity;

namespace Teknoapp.business.Abstract
{
    public interface ICategoryService
    {
        CategoryEntity GetById(int id);

        CategoryEntity GetByIdWithProducts(int categoryId);
        List<CategoryEntity> GetAll();

        void Create(CategoryEntity entity);
        void Update(CategoryEntity entity);
        void Delete(CategoryEntity entity);
        void DeleteFromCategory(int productId, int categoryId);
    }
}
