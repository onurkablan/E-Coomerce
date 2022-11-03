using Microsoft.AspNetCore.Mvc;
using Teknoapp.business.Abstract;
using Teknoapp.entity;
using Teknoapp.webui.Models;

namespace Teknoapp.webui.Controllers
{
    public class TeknoController:Controller
    {
        private IProductService _productService;
        public TeknoController(IProductService productService)

        {
            this._productService = productService;
        }
        public IActionResult List(string category,int page=1)
        {
            const int pageSize = 6;
            var productViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemPerPage = pageSize,
                    CurrentCategory=category
                },
                Products = _productService.GetProductsByCategory(category,page,pageSize)
            };
            return View(productViewModel);
        }
        public IActionResult Details(string url)
        {
            if (Url == null)
            {
                return NotFound();
            }
            ProductEntity product = _productService.GetProductDetails(url);

            if(product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailModel
            {
                Product = product,
                Categories = product.ProductCategories.Select(i=>i.Category).ToList()
            });
        }
        public IActionResult Search(string q)
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetSearchResult(q)
            };
            return View(productViewModel);

        }

    }
}
