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
        //public ActionResult Create()
        //{
        //    ViewBag.Id = new SelectList(db.alumnos, "Id", "nombre");
        //    ViewBag.claseID = new SelectList(db.clases, "claseID", "claseID");
        //    return View();
        //}

        //// POST: Calificacion/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "calificacionID,parcial1,parcial2,parcial3,final,Id,claseID")] Calificacion calificacion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.calificaciones.Add(calificacion);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Id = new SelectList(db.alumnos, "Id", "nombre", calificacion.Id);
        //    ViewBag.claseID = new SelectList(db.clases, "claseID", "claseID", calificacion.claseID);
        //    return View(calificacion);
        //}
        [HttpGet]
        public ActionResult nuevasCalificaciones(int id = 0)
        {
            var clase = db.clases.Include("calificacion").Single(c => c.claseID == id);

            var cals = clase.calificacion.ToList();
            ViewBag.clase = clase;
            return View(cals);
        }
        [HttpPost]
        public ActionResult nuevasCalificaciones(string[] alumnoID, string[] calificacion, string parcial, int claseID)
        {
            string id = alumnoID[0];
            Calificacion cal = db.calificaciones.Single(c => c.Id == id && c.claseID == claseID);

            if (parcial=="parcial1")
            {
                int index = 0;
                foreach (var Item in calificacion)
                {                   
                    cal.parcial1 = int.Parse(Item);
                   
                    db.Entry(cal).State = EntityState.Modified;
                    db.SaveChanges();
                    index = index + 1;
                    if (index < alumnoID.Length)
                    {
                        id = alumnoID[index];

                        cal = db.calificaciones.Single(c => c.Id == id && c.claseID == claseID);
                    }
                }
            }

            if (parcial=="parcial2")
            {
                int index2 = 0;
                foreach (var Item2 in calificacion)
                {
                   
                   cal.parcial2 = int.Parse(Item2);
                   

                    db.Entry(cal).State = EntityState.Modified;
                    db.SaveChanges();
                    index2 = index2 + 1;
                    if (index2 < alumnoID.Length)
                    {
                        id = alumnoID[index2];

                        cal = db.calificaciones.Single(c => c.Id == id && c.claseID == claseID);
                    }
                }
            }


            if (parcial == "parcial3")
            {
                int index3 = 0;
                foreach (var Item3 in calificacion)
                {

                    cal.parcial3 = int.Parse(Item3);


                    db.Entry(cal).State = EntityState.Modified;
                    db.SaveChanges();
                    index3 = index3 + 1;
                    if (index3 < alumnoID.Length)
                    {
                        id = alumnoID[index3];

                        cal = db.calificaciones.Single(c => c.Id == id && c.claseID == claseID);
                    }
                }
            }


            
            /*db.calificaciones.Add(calificaciones);*/
           
            return RedirectToAction("../Home");
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
        public ActionResult Edit([Bind(Include = "calificacionID,parcial1,parcial2,parcial3,final,Id,claseID")] Calificacion calificacion)
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
