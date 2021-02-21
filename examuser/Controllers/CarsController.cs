using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examuser.Controllers
{
    public class CarsController : Controller
    {
        serviceContext db = new serviceContext();
        // GET: Cars
        public ActionResult GalleryList()
        {
           return View(db.carinfos.ToList());
        }
        public ActionResult Details(int id)
        {
            carinfo cr = new carinfo();
            using(serviceContext dd=new serviceContext())
            {
                cr = dd.carinfos.Where(x => x.car_id == id).FirstOrDefault();
            }
            return View(cr);
        }

    }
}