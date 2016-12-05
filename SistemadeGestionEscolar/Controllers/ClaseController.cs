using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemadeGestionEscolar.Models;

namespace SistemadeGestionEscolar.Controllers
{
    public class ClaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clase
        public ActionResult Index()
        {
            var clases = db.clases.Include(c => c.asignatura).Include(c => c.grupo).Include(c => c.profesor);
            return View(clases.ToList());
        }

        // GET: Clase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clase clase = db.clases.Find(id);
            if (clase == null)
            {
                return HttpNotFound();
            }
            return View(clase);
        }

        // GET: Clase/Create
        public ActionResult Create()
        {
            ViewBag.asignaturaID = new SelectList(db.asignaturas, "asignaturaID", "nombreAsignatura");
            ViewBag.grupoID = new SelectList(db.grupos, "grupoID", "nombreGrupo");
           ViewBag.Id = new SelectList(db.profesores, "Id", "nombre");
            return View();
        }

        // POST: Clase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "claseID,Id,asignaturaID,grupoID")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                db.clases.Add(clase);

                var grupo = db.grupos.Find(clase.grupoID);
                var alumno = grupo.alumnos;

                foreach (var elemento in alumno)
                {
                    Calificacion nuevaCalificacion = new Calificacion();
                    nuevaCalificacion.Id = elemento.Id;
                    nuevaCalificacion.claseID = clase.claseID;

                    db.calificaciones.Add(nuevaCalificacion);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.asignaturaID = new SelectList(db.asignaturas, "asignaturaID", "nombreAsignatura", clase.asignaturaID);
            ViewBag.grupoID = new SelectList(db.grupos, "grupoID", "nombreGrupo", clase.grupoID);
            //ViewBag.profesorID = new SelectList(db.profesores, "profesorID", "nombre", clase.profesorID);
            ViewBag.Id = new SelectList(db.profesores, "Id", "nombre");
            return View(clase);
        }

        // GET: Clase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clase clase = db.clases.Find(id);
            if (clase == null)
            {
                return HttpNotFound();
            }
            ViewBag.asignaturaID = new SelectList(db.asignaturas, "asignaturaID", "nombreAsignatura", clase.asignaturaID);
            ViewBag.grupoID = new SelectList(db.grupos, "grupoID", "nombreGrupo", clase.grupoID);
            ViewBag.Id = new SelectList(db.profesores, "Id", "nombre", clase.Id);
            return View(clase);
        }

        // POST: Clase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "claseID,Id,asignaturaID,grupoID")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.asignaturaID = new SelectList(db.asignaturas, "asignaturaID", "nombreAsignatura", clase.asignaturaID);
            ViewBag.grupoID = new SelectList(db.grupos, "grupoID", "nombreGrupo", clase.grupoID);
            ViewBag.Id = new SelectList(db.profesores, "Id", "nombre", clase.Id);
            return View(clase);
        }

        // GET: Clase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clase clase = db.clases.Find(id);
            if (clase == null)
            {
                return HttpNotFound();
            }
            return View(clase);
        }

        // POST: Clase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clase clase = db.clases.Find(id);
            db.clases.Remove(clase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
