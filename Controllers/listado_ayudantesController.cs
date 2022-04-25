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

        // GET: cliente_ayudante
        public ActionResult Listado()
        {
            var listado_ayudantes = db.listado_ayudantes.Include(l => l.usuarios);
            return View(listado_ayudantes.ToList());
        }
        
        // GET: cliente_ayudante
        public ActionResult Listado_ayudante()
        {
            var listado_ayudantes = db.listado_ayudantes.Include(l => l.usuarios);
            return View(listado_ayudantes.ToList());
        }

        // GET: cliente_ayudante
        public ActionResult Listado_administradores()
        {
            var listado_ayudantes = db.listado_ayudantes.Include(l => l.usuarios);
            return View(listado_ayudantes.ToList());
        }


        // GET: cliente_ayudante/Details/5  
        public ActionResult Calificacion(int? id)
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

        public ActionResult Calificacion_ayudante(int? id)
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

        public ActionResult Calificacion_administrador(int? id)
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

        // GET: cliente_ayudante/Create
        public ActionResult Crear()
        {
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre");
            return View();
        }

        // POST: cliente_ayudante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "codigo,email,descripcion,costo,medioInfo")] listado_ayudantes listado_ayudantes)
        {
            if (ModelState.IsValid)
            {
                db.listado_ayudantes.Add(listado_ayudantes);
                db.SaveChanges();
                return RedirectToAction("listado_ayudante");
            }

            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_ayudantes.email);
            return View(listado_ayudantes);
        }

        // GET: cliente_ayudante/Edit/5
        public ActionResult Editar(int? id)
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

        // POST: cliente_ayudante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codigo,email,descripcion,costo,medioInfo")] listado_ayudantes listado_ayudantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listado_ayudantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listado_ayudante");
            }
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_ayudantes.email);
            return View(listado_ayudantes);
        }


        // GET: cliente_ayudante/Edit/5
        public ActionResult Editar_administradores(int? id)
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

        // POST: cliente_ayudante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar_administadores([Bind(Include = "codigo,email,descripcion,costo,medioInfo")] listado_ayudantes listado_ayudantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listado_ayudantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listado_ayudante");
            }
            ViewBag.email = new SelectList(db.usuarios, "email", "nombre", listado_ayudantes.email);
            return View(listado_ayudantes);
        }

        // GET: cliente_ayudante/Delete/5
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

        // POST: cliente_ayudante/Delete/5
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
