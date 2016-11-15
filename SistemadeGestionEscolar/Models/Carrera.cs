using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SistemadeGestionEscolar.Models
{
    public class Carrera
    {
        [Key]
        public int carreraID { get; set; }
        public String NombreCarrera { get; set; }


        public virtual ICollection<Grupo> grupo { get; set; }

    }
}