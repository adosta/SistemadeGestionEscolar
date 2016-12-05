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
    public class CalificacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Calificacion
        public ActionResult Index()
        {
            var calificaciones = db.calificaciones.Include(c => c.alumno).Include(c => c.clase);
            return View(calificaciones.ToList());
        }

        // GET: Calificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.calificaciones.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // GET: Calificacion/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.alumnos, "Id", "nombre");
            ViewBag.claseID = new SelectList(db.clases, "claseID", "claseID");
            return View();
        }

        // POST: Calificacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "calificacionID,parcial1,parcial2,parcial3,final,Id,claseID")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.calificaciones.Add(calificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.alumnos, "Id", "nombre", calificacion.Id);
            ViewBag.claseID = new SelectList(db.clases, "claseID", "claseID", calificacion.claseID);
            return View(calificacion);
        }

        // GET: Calificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.calificaciones.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.alumnos, "Id", "nombre", calificacion.Id);
            ViewBag.claseID = new SelectList(db.clases, "claseID", "claseID", calificacion.claseID);
            return View(calificacion);
        }

        // POST: Calificacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "calificacionID,parcial1,parcial2,parcial3,final,numeroMatricula,claseID")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.alumnos, "Id", "nombre", calificacion.Id);
            ViewBag.claseID = new SelectList(db.clases, "claseID", "claseID", calificacion.claseID);
            return View(calificacion);
        }

        // GET: Calificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.calificaciones.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // POST: Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificacion calificacion = db.calificaciones.Find(id);
            db.calificaciones.Remove(calificacion);
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
