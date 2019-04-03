using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudiantes.Models.ORM
{
    public class Calificacion
    {
        [Key]
        public int IdCalificacion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdClase { get; set; }
        public int IdPeriodo { get; set; }

        [Display(Name = "Calificación")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int CalificacionFinal { get; set; }

        public virtual Estudiante Estudiante { get; set; }
        public virtual Clase Clase { get; set; }
        public virtual Periodo Periodo { get; set; }

    }
}