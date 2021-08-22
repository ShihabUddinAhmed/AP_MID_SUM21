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
    public class CartTableController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = CartService.GetCarts();
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CartModel p)
        {
            CartService.AddToCart(p);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var p = CartService.GetCart(id);
            return View(p);
        }

        public ActionResult Edit(int id)
        {
            var p = CartService.GetCart(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(CartModel p)
        {
            CartService.EditCart(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var p = CartService.GetCart(Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            CartService.DeleteItem(Id);
            return RedirectToAction("Index");
        }
    }
}