using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoapp.data.Abstract;
using Teknoapp.entity;

namespace Teknoapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<ProductEntity, TeknoContext>, IProductRepository
    {
        public ProductEntity GetByIdWithCategories(int id)
        {
            using(var context = new TeknoContext())
            {
                return context.Products
                                .Where(i => i.ProductId == id)
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault();
                    }           
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new TeknoContext())
            {
                var products = context.Products.Where(i=>i.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == category));
                }
                return products.Count();
            }
        }

        public List<ProductEntity> GetHomePageProducts()
        {
            using (var context = new TeknoContext())
            {
                return context.Products.Where(i => i.IsApproved && i.IsHome).ToList();
            }
        }

        public ProductEntity GetProductDetails(string url)
        {
            using (var context = new TeknoContext())
            {
                return context.Products
                    .Where(i => i.Url == url).Include(i => i.ProductCategories).ThenInclude(i => i.Category).FirstOrDefault();
            }
        }

        public List<ProductEntity> GetProductsByCategory(string name, int page, int pageSize)
        {
            using (var context = new TeknoContext())
            {
                var products = context.Products
                    .Where(i=>i.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));
                }
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public List<ProductEntity> GetSearchResult(string searchString)
        {
            using (var context = new TeknoContext())
            {
                var products = context.Products
                    .Where(i => i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) ||(i.Marka.ToLower().Contains(searchString.ToLower()))|| i.Description.ToLower().Contains(searchString.ToLower())))
                    .AsQueryable();
                    
                return products.ToList();
            }
        }

        public void Update(ProductEntity entity, int[] categoryId)
        {
            using (var context =new TeknoContext())
            {
               var product = context.Products
                    .Include(i=>i.ProductCategories)
                    .FirstOrDefault(i => i.ProductId == entity.ProductId);
                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Marka = entity.Marka;
                    product.Description = entity.Description;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;
                    product.IsApproved= entity.IsApproved;
                    product.IsHome = entity.IsHome;
                    product.ProductCategories = categoryId.Select(catid => new ProductCategory()
                    {
                        ProductId=entity.ProductId,
                        CategoryId=catid,
                    }).ToList();
                    context.SaveChanges();
                }

            }
        }
    }
}
