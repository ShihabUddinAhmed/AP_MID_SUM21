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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = ProductService.GetAllProducts();
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel p)
        {
            ProductService.AddProduct(p);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var p = ProductService.GetProduct(id);
            return View(p);
        }

        public ActionResult Edit(int id)
        {
            var p = ProductService.GetProduct(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel p)
        {
            ProductService.EditProduct(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var p = ProductService.GetProduct(Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            ProductService.DeleteProduct(Id);
            return RedirectToAction("Index");
        }

    }
}