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
    public class GrupoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Grupo
        public ActionResult Index()
        {
            return View(db.grupos.ToList());
        }

        // GET: Grupo/Details/5
        [Authorize(Roles = "Admin ,Caturista")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // GET: Grupo/Create
        [Authorize(Roles = "Admin ,Caturista")]
        public ActionResult Create()
        {

            var carreras = db.carreras;
            SelectList carreraID = new SelectList(carreras, "carreraID", "NombreCarrera");

            ViewBag.carreraID = carreraID;
            return View();

        }

        // POST: Grupo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "grupoID,nombreGrupo,carrera")] Grupo grupo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.grupos.Add(grupo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(grupo);
        //}

        [HttpPost]
        public ActionResult Create(Grupo grupoNuevo, bool enDetallesDeCarrera = false)
        {
            if (ModelState.IsValid)
            {
                db.grupos.Add(grupoNuevo);
                db.SaveChanges();
                if (enDetallesDeCarrera)
                {
                    return RedirectToAction("Details", "carreras", new { id = grupoNuevo.carreraID });
                }
                else
                {
                    //Regresar una Vista
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MensajeError = "Hubo un error, Favor de verificar los datos";
            var carreras = db.carreras;
            SelectList carreraID = new SelectList(carreras, "carreraID", "carrera");

            ViewBag.carreraID = carreraID;
            return View();
        }

        // GET: Grupo/Edit/5
        [Authorize(Roles = "Admin ,Caturista")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: Grupo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin ,Caturista")]
        public ActionResult Edit([Bind(Include = "grupoID,nombreGrupo,carrera")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupo);
        }

        // GET: Grupo/Delete/5
        [Authorize(Roles = "Admin ")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: Grupo/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.grupos.Find(id);
            db.grupos.Remove(grupo);
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
