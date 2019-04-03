using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudiantes.Models.ORM
{
    public class Clase
    {
        [Key]
        public int IdClase { get; set; }

        [Display(Name = "Nombre de Clase")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo tiene como máximo {1} caracteres")]
        public string NombreClase { get; set; }

        public ICollection<Calificacion> Calificaciones { get; set; }
    }
}