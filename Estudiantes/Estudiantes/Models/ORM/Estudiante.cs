using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudiantes.Models.ORM
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }

        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo tiene como máximo {1} caracteres")]
        public string Matricula { get; set; }

        [Display(Name = "Nombre de Alumno")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo tiene como máximo {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public byte Edad { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo tiene como máximo {1} caracteres")]
        public string Sexo { get; set; }

        public ICollection<Calificacion> Calificaciones { get; set; }

    }
}