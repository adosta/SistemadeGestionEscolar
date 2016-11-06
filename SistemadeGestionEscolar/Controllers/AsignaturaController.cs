using SistemadeGestionEscolar.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemadeGestionEscolar.Controllers
{
    public class AsignaturaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        [Authorize(Roles = "Admin ,Caturista")]
        public ActionResult Listar(string nombreBuscado)
        {
            var resultadoDeBusqueda = new List<Asignatura>();

            //consultar la lista de alumnos
            //select * FROM alumnos
            if (!string.IsNullOrEmpty(nombreBuscado))
            {
                resultadoDeBusqueda = db.asignaturas.Where(a => a.nombreAsignatura.Contains(nombreBuscado)).ToList();
            }
            else
            {
                resultadoDeBusqueda = db.asignaturas.ToList();

            }

            //pedirle a la lista que muestre los resultados en pantalla

            return View(resultadoDeBusqueda);
        }

        [HttpGet]
        public ActionResult Listar()
        {


            //consultar la lista de alumnos
            //select * FROM alumnos
            var todosLosAlumnos = db.asignaturas.ToList();


            //pedirle a la lista que muestre los resultados en pantalla

            return View(todosLosAlumnos);
        }
    }
}