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
    public class EstudiantesController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new LocalDataContext())
            {
                return View(db.Estudiantes.ToList()); 
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                using (var db = new LocalDataContext())
                {
                    db.Estudiantes.Add(estudiante);
                    db.SaveChanges(); 
                }
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Estudiante estudiante = new Estudiante();

            using (var db = new LocalDataContext())
            {
                estudiante = db.Estudiantes.Find(id);
            }
            
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Edit(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                using (var db = new LocalDataContext())
                {
                    db.Estudiantes.Add(estudiante);
                    db.SaveChanges();
                }
            }
            return View(estudiante);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Estudiante estudiante = new Estudiante();

            using (var db = new LocalDataContext())
            {
                estudiante = db.Estudiantes.Find(id);
            }

            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiante estudiante = new Estudiante();

            using (var db = new LocalDataContext())
            {
                estudiante = db.Estudiantes.Find(id);
                db.Estudiantes.Remove(estudiante);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}
