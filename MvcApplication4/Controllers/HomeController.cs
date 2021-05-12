using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class HomeController : Controller
    {

        DataClasses1DataContext dc = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test(int id)
        {
            return View(dc.contact1s.First(c => c.Id == id));
        }

        public ActionResult Contact()
        {
            return View(dc.contact1s.ToList());
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }
        //functions
        public ActionResult Add()
        {
            //get all inputs
            string name = Request["name"];
            string price = Request["price"];
            string brand = Request["brand"];
            string desc = Request["desc"];


            contact1 p = new contact1();
            //put in db
            p.Name = name;
            p.PRICE = price;
            p.BRAND = brand;
            p.DESC = desc;

            dc.contact1s.InsertOnSubmit(p);
            dc.SubmitChanges();
            return RedirectToAction("Contact");
        }

        public ActionResult Delete(int id)
        {
            var s = dc.contact1s.First(x => x.Id == id);
            dc.contact1s.DeleteOnSubmit(s);
            dc.SubmitChanges();
            return RedirectToAction("Contact");
        }

        public ActionResult EditDone(int id)
        {
            var a = dc.contact1s.First(s => s.Id == id);
            var n = Request["name"];
            var p= Request["price"];
            var b = Request["brand"];
            var d = Request["desc"];

            a.Name = n;
            a.PRICE = p;
            a.BRAND = b;
            a.DESC = d;


            dc.SubmitChanges();
            return RedirectToAction("Contact");
        }


    }
}
