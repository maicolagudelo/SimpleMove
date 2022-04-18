using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleMove.Models;

namespace SimpleMove.Controllers
{
    public class listado_ayudantesController : Controller
    {
        private simplemove db = new simplemove();

        // GET: listado_ayudantes
        public ActionResult Index()
        {
            var listado_ayudantes = db.listado_ayudantes.Include(l => l.usuarios);
            return View(listado_ayudantes.ToList());
        }

        // GET: listado_ayudantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listado_ayudantes listado_ayudantes = db.listado_ayudantes.Find(id);
            if (listado_ayudantes == null)
            {
                return HttpNotFound();
            }
            return View(listado_ayudantes);
        }

        // GET: listado_ayudantes/Create
        public ActionResult Create()
        {
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre");
            return View();
        }

        // POST: listado_ayudantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,email,descripcion,costo,medioInfo")] listado_ayudantes listado_ayudantes)
        {
            if (ModelState.IsValid)
            {
                db.listado_ayudantes.Add(listado_ayudantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_ayudantes.email);
            return View(listado_ayudantes);
        }

        // GET: listado_ayudantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listado_ayudantes listado_ayudantes = db.listado_ayudantes.Find(id);
            if (listado_ayudantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_ayudantes.email);
            return View(listado_ayudantes);
        }

        // POST: listado_ayudantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,email,descripcion,costo,medioInfo")] listado_ayudantes listado_ayudantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listado_ayudantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_ayudantes.email);
            return View(listado_ayudantes);
        }

        // GET: listado_ayudantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listado_ayudantes listado_ayudantes = db.listado_ayudantes.Find(id);
            if (listado_ayudantes == null)
            {
                return HttpNotFound();
            }
            return View(listado_ayudantes);
        }

        // POST: listado_ayudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            listado_ayudantes listado_ayudantes = db.listado_ayudantes.Find(id);
            db.listado_ayudantes.Remove(listado_ayudantes);
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
