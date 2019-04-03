using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudiantes.Models.ORM
{
    public class Periodo
    {
        [Key]
        public int IdPeriodo { get; set; }

        [Display(Name = "Periodo Escolar")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo tiene como máximo {1} caracteres")]
        public string NombrePeriodo { get; set; }

        public ICollection<Calificacion> Calificaciones { get; set; }
    }
}