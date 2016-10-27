using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemadeGestionEscolar.Models
{
    public class Grupo
    {
        public int grupoID { get; set; }

        public String nombreGrupo { get; set; }

        public String carrera { get; set; }

        public virtual ICollection<Alumno> alumnos { get; set; }
    }
}