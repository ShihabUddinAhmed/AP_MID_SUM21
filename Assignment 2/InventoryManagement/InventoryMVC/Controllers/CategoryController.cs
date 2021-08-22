using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryMVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = CategoryService.GetCategories();
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel p)
        {
            CategoryService.AddCategory(p);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var p = CategoryService.GetCategoryDetail(id);
            return View(p);
        }

        public ActionResult Edit(int id)
        {
            var p = CategoryService.GetCategory(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel p)
        {
            CategoryService.EditCategory(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var p = CategoryService.GetCategory(Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            CategoryService.DeleteCategory(Id);
            return RedirectToAction("Index");
        }
    }
}