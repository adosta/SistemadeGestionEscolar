using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemadeGestionEscolar.Models;
using System.Data.Entity;


namespace SistemadeGestionEscolar.Controllers
{
    public class GrupoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Listar()
        {
            var todosLosGrupos = db.grupos.ToList();
            return View(todosLosGrupos);
        }

        [HttpPost]
        public ActionResult Listar(string nombreBuscado)
        {
            var resultadoDeBusqueda = new List<Grupo>();

            //consultar la lista de alumnos
            //select * FROM alumnos
            if (!string.IsNullOrEmpty(nombreBuscado))
            {
                resultadoDeBusqueda = db.grupos.Where(a => a.nombreGrupo.Contains(nombreBuscado) ||
                a.carrera.Contains(nombreBuscado)).ToList();
            }
            else
            {
                resultadoDeBusqueda = db.grupos.ToList();

            }

            //pedirle a la lista que muestre los resultados en pantalla

            return View(resultadoDeBusqueda);
        }

        [HttpGet]
        [Authorize(Roles = "Admin ,Capturista")]
        public ActionResult crear()
        {

            return View();
        }

        [HttpPost]
        public ActionResult crear(Grupo grupoNuevo)
        {
            if (ModelState.IsValid)
            {
                db.grupos.Add(grupoNuevo);
                db.SaveChanges();
                return RedirectToAction("listar");
            }
            ViewBag.MensajeError = "Hubo un error, Favor de verificar los datos";
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult eliminar(int id = 0)
        {
            var grupo = db.grupos.Find(id);
            if (grupo == null)
            {
                return RedirectToAction("listar");
            }
            else
            {
                return View(grupo);
            }

        }

        [HttpPost]
        [ActionName("eliminar")]
        [Authorize(Roles = "Admin")]
        public ActionResult confirmarEliminar(int grupoID = 0)
        {
            var grupo = db.grupos.Find(grupoID);

            if (grupo == null)
            {
                return RedirectToAction("listar");
            }

            db.grupos.Remove(grupo);
            db.SaveChanges();
            return RedirectToAction("listar");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult editar(int id = 0)
        {
            var grupo = db.grupos.Find(id);
            if (grupo == null)
            {
                return RedirectToAction("listar");
            }
            //var grupo = db.grupos;
            //SelectList grupoID = new SelectList(grupo, "grupoID", "nombreGrupo");
            //ViewBag.grupoID = grupoID;
            return View(grupo);
        }

        [HttpPost]
        [Authorize(Roles = "Admin ")]
        public ActionResult editar(Grupo grupoEditado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoEditado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listar");
            }
            return View();
        }

        [Authorize(Roles = "Admin ")]
        public ActionResult detalles(int id = 0)
        {
            var grupos = db.grupos.Find(id);

            if (grupos == null)
            {
                RedirectToAction("listar");

            }
            return View(grupos);
        }


    }
}