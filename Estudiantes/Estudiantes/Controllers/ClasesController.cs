using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estudiantes.Models;
using Estudiantes.Models.ORM;

namespace Estudiantes.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClasesController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new LocalDataContext())
            {
                return View(db.Clases.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Clase clase)
        {
            if (ModelState.IsValid)
            {
                using (var db = new LocalDataContext())
                {
                    db.Clases.Add(clase);
                    db.SaveChanges(); 
                }
                return RedirectToAction("Index");
            }

            return View(clase);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clase clase = new Clase();

            using (var db = new LocalDataContext())
            {
                clase = db.Clases.Find(id);
            }
            if (clase == null)
            {
                return HttpNotFound();
            }
            return View(clase);
        }

        [HttpPost]
        public ActionResult Edit(Clase clase)
        {
            if (ModelState.IsValid)
            {
                using (var db = new LocalDataContext())
                {
                    db.Clases.Add(clase);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(clase);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Clase clase = new Clase();

            using (var db = new LocalDataContext())
            {
                clase = db.Clases.Find(id); 
            }

            if (clase == null)
            {
                return HttpNotFound();
            }
            return View(clase);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new LocalDataContext())
            {
                Clase clase = db.Clases.Find(id);
                db.Clases.Remove(clase);
                db.SaveChanges(); 
            }
            return RedirectToAction("Index");
        }
    }
}
