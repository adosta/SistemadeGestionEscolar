using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemadeGestionEscolar.Models
{
    public class Grupo
    {
        public int grupoID { get; set; }

        public String nombreGrupo { get; set; }

        
        [Display(Name = "Carrera")]
        public int carreraID { get; set; }
        virtual public Carrera carrera { get; set; }

        public virtual ICollection<Alumno> alumnos { get; set; }

        public virtual ICollection<Clase> clases { get; set; }

    }
}