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
    public class OrderController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = OrderService.GetOders();
            return View(products);
        }

        public ActionResult Create()
        {
            OrderService.CreateOrder();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            var p = OrderService.GetOrder(id);
            return View(p);
        }

        public ActionResult OrderDetails(string id)
        {
            var p = OrderService.GetOrderDetails(id);
            return View(p);
        }

        public ActionResult Delete(int Id)
        {
            var p = OrderService.GetOrder(Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            OrderService.DeleteOrder(Id);
            return RedirectToAction("Index");
        }
    }
}