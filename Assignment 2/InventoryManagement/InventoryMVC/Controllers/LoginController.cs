using InventoryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InventoryMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin, string ReturnUrl)
        {
            if(admin.Username != null && admin.Password != null)
            {
                if (admin.Username.Equals("shihabahmed") && admin.Password.Equals("12345678"))
                {
                    FormsAuthentication.SetAuthCookie("shihabahmed", false);
                    return Redirect(ReturnUrl);
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Product");
        }
    }
}