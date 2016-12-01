using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemadeGestionEscolar.Models
{
    public class Profesor:ApplicationUser
    {
        //[Key]
        //public int profesorID { get; set; }

        //[Required]

        //[Display(Name = "Nombre")]
        //public string nombre { get; set; }

        //[Required]
        //[Display(Name = "Apellido Paterno")]
        //public string apellidoPaterno { get; set; }

        //[Required]
        //[Display(Name = "Apellido Materno")]
        //public string apellidoMaterno { get; set; }

        //[Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public DateTime fechaDeNacimiento { get; set; }


        [Display(Name = "Especialidad")]
        public string especialidad { get; set; }

        
        [Display(Name = "Grado")]
        public string grado { get; set; }

        public virtual ICollection<Clase> clase { get; set; }

        public Profesor(RegisterViewModel model)
        {
            this.UserName = model.Email;
            this.Email = model.Email;
            this.nombre = model.nombre;
            this.apellidoPaterno = model.apellidoPaterno;
            this.apellidoMaterno = model.apellidoMaterno;
            this.fechaDeNacimiento = model.fechaDeNacimiento;
            this.rol = model.rol;
            this.especialidad = model.especialidad;
            this.grado = model.grado;
        }

        public Profesor()
        {

        }
        
    }
}