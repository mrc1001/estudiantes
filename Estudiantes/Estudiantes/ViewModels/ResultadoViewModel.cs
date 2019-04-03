using Estudiantes.Models.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estudiantes.ViewModels
{
    public class ResultadoViewModel : Calificacion
    {
        public IEnumerable<SelectListItem> Periodos { set; get; }
        public IEnumerable<SelectListItem> Clases { set; get; }
        public IEnumerable<Calificacion> Datos { get; set; }
    }
}