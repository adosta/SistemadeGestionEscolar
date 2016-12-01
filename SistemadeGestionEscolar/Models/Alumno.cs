using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemadeGestionEscolar.Models
{
    public class Alumno: ApplicationUser
    {


        
        [Display(Name = "Carrera Preferida")]
        public string carreraPreferida { get; set; }


        [Display(Name = "Grupo")]
        public int? grupoID { get; set; }
        virtual public Grupo grupo { get; set; }

        public virtual ICollection<Calificacion> calificaciones { get; set; }

        public Alumno(RegisterViewModel model)
        {
            this.UserName = model.Email;
            this.Email = model.Email;
            this.nombre = model.nombre;
            this.apellidoPaterno = model.apellidoPaterno;
            this.apellidoMaterno = model.apellidoMaterno;
            this.fechaDeNacimiento = model.fechaDeNacimiento;
            this.rol = model.rol;
            this.carreraPreferida = model.carreraPreferida;
            //this.grupo.nombreGrupo = model.grupoID;
        }
        public Alumno()
        {

        }
    }
}