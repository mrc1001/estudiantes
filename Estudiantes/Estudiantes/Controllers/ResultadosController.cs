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
    [Authorize(Roles = "Admin")]
    public class ResultadosController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

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
    }
}
