using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoapp.entity;

namespace Teknoapp.data.Abstract
{
    public interface ICategoryRepository:IRepository<CategoryEntity>

    {

        CategoryEntity GetByIdWithProducts(int categoryId);

        void DeleteFromCategory(int productId, int categoryId);
    }
}
