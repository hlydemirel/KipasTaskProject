using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Projem.Models.Entity;


namespace Projem.Controllers
{
    public class HomeController : Controller
    {


       projedbEntities1  db = new projedbEntities1();

        public ActionResult Index()
        {
            var employeeslist = db.PersonelTable.ToList();

            return View(employeeslist);
        }

        [HttpPost]
        public ActionResult Guncelle(PersonelTable update1)
        {
            var personel = db.PersonelTable.Find(update1.id);
            personel.name = update1.name;
            personel.surname = update1.surname;
            personel.age = update1.age;
            personel.position = update1.position;
            personel.identityNo = update1.identityNo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetPersonelForEdit(int id)
        {
            var per = db.PersonelTable.Find(id);
            return PartialView("_EditPersonelPartial", per);
        }

    }
}