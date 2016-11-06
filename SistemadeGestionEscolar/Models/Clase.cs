using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemadeGestionEscolar.Models
{
    public class Clase
    {
        [Key]
        public int claseID { get; set; }

        [Required]
        [Display(Name = "Profesor")]
        public int profesorID { get; set; }

        [Required]
        [Display(Name = "Asignatura")]
        public int asignaturaID { get; set; }

        virtual public Profesor profesor { get; set; }

        virtual public Asignatura asignatura { get; set; }
    }
}