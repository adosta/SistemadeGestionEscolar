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
        public virtual Profesor profesor { get; set; }

        [Required]
        [Display(Name = "Asignatura")]
        public int asignaturaID { get; set; }
        public virtual Asignatura asignatura { get; set; }

        [Required]
        [Display(Name = "Grupo")]
        public int grupoID { get; set; }
        public virtual Grupo grupo { get; set; }

        public virtual ICollection<Calificacion> calificacion { get; set; }
    }
}