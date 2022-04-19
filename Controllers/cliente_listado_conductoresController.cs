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
    public class cliente_listado_conductoresController : Controller
    {
        private simplemove db = new simplemove();

        // GET: cliente_listado_conductores
        public ActionResult Listado()
        {
            var listado_conductores = db.listado_conductores.Include(l => l.usuarios);
            return View(listado_conductores.ToList());
        }

        // GET: cliente_listado_conductores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listado_conductores listado_conductores = db.listado_conductores.Find(id);
            if (listado_conductores == null)
            {
                return HttpNotFound();
            }
            return View(listado_conductores);
        }

        // GET: cliente_listado_conductores/Create
        public ActionResult Create()
        {
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre");
            return View();
        }

        // POST: cliente_listado_conductores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,email,descripcion,costo,medioInfo,capacidad")] listado_conductores listado_conductores)
        {
            if (ModelState.IsValid)
            {
                db.listado_conductores.Add(listado_conductores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_conductores.email);
            return View(listado_conductores);
        }

        // GET: cliente_listado_conductores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listado_conductores listado_conductores = db.listado_conductores.Find(id);
            if (listado_conductores == null)
            {
                return HttpNotFound();
            }
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_conductores.email);
            return View(listado_conductores);
        }

        // POST: cliente_listado_conductores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,email,descripcion,costo,medioInfo,capacidad")] listado_conductores listado_conductores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listado_conductores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_conductores.email);
            return View(listado_conductores);
        }

        // GET: cliente_listado_conductores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listado_conductores listado_conductores = db.listado_conductores.Find(id);
            if (listado_conductores == null)
            {
                return HttpNotFound();
            }
            return View(listado_conductores);
        }

        // POST: cliente_listado_conductores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            listado_conductores listado_conductores = db.listado_conductores.Find(id);
            db.listado_conductores.Remove(listado_conductores);
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
