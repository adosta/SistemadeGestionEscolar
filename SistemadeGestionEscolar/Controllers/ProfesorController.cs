using SistemadeGestionEscolar.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemadeGestionEscolar.Controllers
{
    public class ProfesorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        [Authorize(Roles = "Admin ,Caturista")]
        public ActionResult Listar(string nombreBuscado)
        {
            var resultadoDeBusqueda = new List<Profesor>();

            //consultar la lista de alumnos
            //select * FROM alumnos
            if (!string.IsNullOrEmpty(nombreBuscado))
            {
                resultadoDeBusqueda = db.profesores.Where(a => a.nombre.Contains(nombreBuscado) ||
                a.apellidoPaterno.Contains(nombreBuscado) ||
                a.apellidoMaterno.Contains(nombreBuscado)).ToList();
            }
            else
            {
                resultadoDeBusqueda = db.profesores.ToList();

            }

            //pedirle a la lista que muestre los resultados en pantalla

            return View(resultadoDeBusqueda);
        }
        
        [HttpGet]
        public ActionResult Listar()
        {


            //consultar la lista de alumnos
            //select * FROM alumnos
            var todosLosAlumnos = db.alumnos.ToList();


            //pedirle a la lista que muestre los resultados en pantalla

            return View(todosLosAlumnos);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin ,Capturista")]
        public ActionResult crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crear(Profesor profesorNuevo)
        {
            if (ModelState.IsValid)
                {
                    db.profesores.Add(profesorNuevo);
                    db.SaveChanges();
                    return RedirectToAction("listar");
                }
                ViewBag.MensajeError = "Hubo un error, Favor de verificar los datos";
                return View();
            }

        [Authorize(Roles = "Admin")]
        public ActionResult eliminar(int id = 0)
        {
            var profesor = db.profesores.Find(id);
            if (profesor == null)
            {
                return RedirectToAction("listar");
            }
            else
            {
                return View(profesor);
            }


        }

        [HttpPost]
        [ActionName("eliminar")]
        [Authorize(Roles = "Admin")]
        public ActionResult confirmarEliminar(int profesorID = 0)
        {

            var profesor = db.profesores.Find(profesorID);

            if (profesor == null)
            {
                return RedirectToAction("listar");
            }

            db.profesores.Remove(profesor);
            db.SaveChanges();//Ejecuta la lista de querys en la BD
            return RedirectToAction("listar");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Capturista")]
        public ActionResult editar(int id = 0)
        {
            var profesor = db.profesores.Find(id);
            if (profesor == null)
            {
                return RedirectToAction("listar");
            }
           // var grupo = db.grupos;
            //SelectList grupoID = new SelectList(grupo, "grupoID", "nombreGrupo");
            //ViewBag.grupoID = grupoID;
            return View(profesor);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Capturista ")]
        public ActionResult editar(Alumno profesorEditado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesorEditado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listar");
            }
            return View();
        }

        [Authorize(Roles = "Admin ")]
        public ActionResult DetallesProfesor(int id = 0)
        {
            var profesores = db.profesores.Find(id);

            if (profesores == null)
            {
                RedirectToAction("listar");

            }
            return View(profesores);
        }
    }
} 