using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemadeGestionEscolar.Models
{
    public class Asignatura
    {
        [Key]
        public int asignaturaID { get; set; }

        [Required]
        [Display(Name = "Nombre de Asignatura")]
        public string nombreAsignatura { get; set; }
        
        public virtual ICollection<Clase> clase { get; set; }
    }
}