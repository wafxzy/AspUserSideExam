using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examuser.Controllers
{
    public class OrderController : Controller
    {
        serviceContext db = new serviceContext();

        public ActionResult Regend()
        {
            return View();
        }
        // GET: Order
        [HttpGet]
        public ActionResult PreOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PreOrder(uss user)
        {
            if (ModelState.IsValid)
            {
                db.usses.Add(user);
                db.SaveChanges();
                
                return RedirectToAction("Regend");
            }
            return View(user);
        }
    }
}