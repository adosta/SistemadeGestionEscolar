using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemadeGestionEscolar.Models
{
    public class Calificacion
    {
        [Key]
        public int calificacionID { get; set; }

        public int parcial1 { get; set; }
        public int parcial2 { get; set; }
        public int parcial3 { get; set; }
        public int final { get; set; }

        public int numeroMatricula { get; set; }
        virtual public Alumno alumno { get; set; }

        public int claseID { get; set; }
        virtual public Profesor clase { get; set; }
    }
}