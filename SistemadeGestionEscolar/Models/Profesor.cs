using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemadeGestionEscolar.Models
{
    public class Profesor
    {
        [Key]
        public int profesorID { get; set; }

        [Required]
        [MinLength(1)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string apellidoPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string apellidoMaterno { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaDeNacimiento { get; set; }

        public virtual ICollection<Clase> clase { get; set; }
        
    }
}