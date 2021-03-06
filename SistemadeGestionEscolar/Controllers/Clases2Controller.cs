﻿using System;
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
    public class Clases2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clases2
        public ActionResult Index()
        {
            var clases = db.clases.Include(c => c.asignatura).Include(c => c.grupo);
            return View(clases.ToList());
        }

        // GET: Clases2/Details/5
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

        // GET: Clases2/Create
        public ActionResult Create()
        {
            ViewBag.asignaturaID = new SelectList(db.asignaturas, "asignaturaID", "nombreAsignatura");
            ViewBag.grupoID = new SelectList(db.grupos, "grupoID", "nombreGrupo");
            return View();
        }

        // POST: Clases2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "claseID,profesorID,asignaturaID,grupoID")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                db.clases.Add(clase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.asignaturaID = new SelectList(db.asignaturas, "asignaturaID", "nombreAsignatura", clase.asignaturaID);
            ViewBag.grupoID = new SelectList(db.grupos, "grupoID", "nombreGrupo", clase.grupoID);
            return View(clase);
        }

        // GET: Clases2/Edit/5
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
            return View(clase);
        }

        // POST: Clases2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "claseID,profesorID,asignaturaID,grupoID")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.asignaturaID = new SelectList(db.asignaturas, "asignaturaID", "nombreAsignatura", clase.asignaturaID);
            ViewBag.grupoID = new SelectList(db.grupos, "grupoID", "nombreGrupo", clase.grupoID);
            return View(clase);
        }

        // GET: Clases2/Delete/5
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

        // POST: Clases2/Delete/5
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
