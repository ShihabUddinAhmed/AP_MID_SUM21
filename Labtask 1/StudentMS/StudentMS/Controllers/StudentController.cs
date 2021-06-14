using StudentMS.Models;
using StudentMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMS.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";
            Admin admin = new Admin();
            return View(admin);
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            if(ModelState.IsValid)
            {
                Database database = new Database();
                bool auth = database.Admins.AuthenticateAdmin(admin);
                if (auth)
                {
                    return RedirectToAction("DashBoard");
                }
                else
                    return View(admin);
            }
            return View(admin);
        }

        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult Students()
        {
            Database database = new Database();
            var students = database.Students.GetAll();
            
            return View(students);
        }

        public ActionResult AddStudent()
        {
            Student student = new Student();
            return View(student);
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if(ModelState.IsValid)
            {
                Database database = new Database();
                database.Students.Insert(student);
                return RedirectToAction("Students");
            }
            return View(student);
        }

        public ActionResult EditStudent(int id)
        {
            Database database = new Database();
            var student = database.Students.Get(id);

            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            if(ModelState.IsValid)
            {
                Database database = new Database();
                database.Students.Edit(student);
                return RedirectToAction("Students");
            }
            return View();
        }

        public ActionResult Departments()
        {
            Database database = new Database();
            var dept = database.Departments.GetAll();
            return View(dept);
        }

        public ActionResult Delete(int id)
        {
            Database database = new Database();
            database.Students.Delete(id);
            return RedirectToAction("Students");
        }
    }
}