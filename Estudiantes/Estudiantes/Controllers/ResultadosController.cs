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
using Estudiantes.ViewModels;

namespace Estudiantes.Controllers
{
    public class ResultadosController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Resultados
        public ActionResult Index(string filterPeriodo = "", string filterClase = "")
        {
            ResultadoViewModel calificaciones = null;

            using (var db = new LocalDataContext())
            {
                calificaciones.Clases = new SelectList(db.Clases, "IdClase", "NombreClase");
                calificaciones.Periodos = new SelectList(db.Periodoes, "IdPeriodo", "NombrePeriodo");

                var calif = db.Calificacions.Include(c => c.Clase).Include(c => c.Estudiante).Include(c => c.Periodo);

                calificaciones.Datos = calif.ToList();

                if (!string.IsNullOrEmpty(filterPeriodo))
                {
                    int idPeriodo = 0;
                    int.TryParse(filterPeriodo, out idPeriodo);
                    calificaciones.Datos = calif.Where(c => c.IdPeriodo == idPeriodo).ToList();
                }
                if (!string.IsNullOrEmpty(filterClase))
                {
                    int idClase = 0;
                    int.TryParse(filterClase, out idClase);
                    calificaciones.Datos = calif.Where(c => c.IdPeriodo == idClase).ToList();
                }
            }
            return View(calificaciones);
        }

        //// GET: Resultados/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IdClase = new SelectList(db.Clases, "IdClase", "NombreClase");
        //    ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Matricula");
        //    ViewBag.IdPeriodo = new SelectList(db.Periodoes, "IdPeriodo", "NombrePeriodo");
        //    return View();
        //}

        //// POST: Resultados/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IdCalificacion,IdEstudiante,IdClase,IdPeriodo,CalificacionFinal")] Calificacion calificacion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Calificacions.Add(calificacion);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IdClase = new SelectList(db.Clases, "IdClase", "NombreClase", calificacion.IdClase);
        //    ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Matricula", calificacion.IdEstudiante);
        //    ViewBag.IdPeriodo = new SelectList(db.Periodoes, "IdPeriodo", "NombrePeriodo", calificacion.IdPeriodo);
        //    return View(calificacion);
        //}

        //// GET: Resultados/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Calificacion calificacion = db.Calificacions.Find(id);
        //    if (calificacion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.IdClase = new SelectList(db.Clases, "IdClase", "NombreClase", calificacion.IdClase);
        //    ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Matricula", calificacion.IdEstudiante);
        //    ViewBag.IdPeriodo = new SelectList(db.Periodoes, "IdPeriodo", "NombrePeriodo", calificacion.IdPeriodo);
        //    return View(calificacion);
        //}

        //// POST: Resultados/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IdCalificacion,IdEstudiante,IdClase,IdPeriodo,CalificacionFinal")] Calificacion calificacion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(calificacion).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.IdClase = new SelectList(db.Clases, "IdClase", "NombreClase", calificacion.IdClase);
        //    ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Matricula", calificacion.IdEstudiante);
        //    ViewBag.IdPeriodo = new SelectList(db.Periodoes, "IdPeriodo", "NombrePeriodo", calificacion.IdPeriodo);
        //    return View(calificacion);
        //}

        //// GET: Resultados/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Calificacion calificacion = db.Calificacions.Find(id);
        //    if (calificacion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(calificacion);
        //}

        //// POST: Resultados/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Calificacion calificacion = db.Calificacions.Find(id);
        //    db.Calificacions.Remove(calificacion);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
