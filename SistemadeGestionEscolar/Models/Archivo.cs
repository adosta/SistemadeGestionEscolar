using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemadeGestionEscolar.Models
{
    public class Archivo
    {

        public int archivoID { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string formatoContenido { get; set; }
        public byte[] contenido { get; set; }

        public int Id { get; set; }
        public Alumno alumno { get; set; }


    }
}