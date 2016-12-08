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

        public Alumno(RegisterViewModel model) : base(model)
        {
            
            
            this.carreraPreferida = model.carreraPreferida;
            //this.grupo.nombreGrupo = model.grupoID;
        }
        public Alumno()
        {

        }
    }
}