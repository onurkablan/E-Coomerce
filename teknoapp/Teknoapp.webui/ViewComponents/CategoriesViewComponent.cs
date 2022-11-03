using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Teknoapp.business.Abstract;

namespace Teknoapp.webui.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)

        {
            this._categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"]!=null)
            ViewBag.Selectedcategory = RouteData?.Values["category"];
            return View(_categoryService.GetAll());

        }
    }
}
