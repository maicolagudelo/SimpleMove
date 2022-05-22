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


        



        // Cliente
        public ActionResult Listado()
        {
            if (Session["UserTelefono"] != null)
            {
                var listado_ayudantes = db.listado_ayudantes.Include(l => l.usuarios);
                
                return View(listado_ayudantes.ToList());
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // GET: cliente_ayudante/Details/5  
        public ActionResult Calificacion(int? id)
        {


            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }

        }






        // Ayudante
        public ActionResult Listado_ayudante()
        {
            if (Session["UserTelefono"] != null)
            {
                var listado_ayudantes = db.listado_ayudantes.Include(l => l.usuarios);

                return View(listado_ayudantes.ToList());
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }  

        public ActionResult Calificacion_ayudante(int? id)
        {

            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }



        public ActionResult Crear()
        {


            if (Session["UserTelefono"] != null)
            {
               
                
                ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre");
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        // POST: listado_ayudantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "codigo,descripcion,costo,medioInfo,telefono")] listado_ayudantes listado_ayudantes)
        {

           
            if (ModelState.IsValid)
            {
                db.listado_ayudantes.Add(listado_ayudantes);
                db.SaveChanges();
                return RedirectToAction("listado_ayudante");
            }
            ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre", listado_ayudantes.telefono);
            return View(listado_ayudantes);
        }

        // GET: listado_ayudantes/Edit/5
        public ActionResult Editar(int? id)
        {
            if (Session["UserTelefono"] != null)
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
                ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre", listado_ayudantes.telefono);
                return View(listado_ayudantes);
            }

            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // POST: listado_ayudantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codigo,descripcion,costo,medioInfo,telefono")] listado_ayudantes listado_ayudantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listado_ayudantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listado_ayudante");
            }
            ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre", listado_ayudantes.telefono);
            return View(listado_ayudantes);
        }


        public ActionResult Delete_ayudante(int? id)
        {
            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // POST: cliente_ayudante/Delete/5
        [HttpPost, ActionName("Delete_ayudante")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_ayudante(int id)
        {
            listado_ayudantes listado_ayudantes = db.listado_ayudantes.Find(id);
            db.listado_ayudantes.Remove(listado_ayudantes);
            db.SaveChanges();
            return RedirectToAction("Listado_ayudante");
        }

        // Administrador
        public ActionResult Listado_administradores()
        {
            if (Session["UserTelefono"] != null)
            {
                var listado_ayudantes = db.listado_ayudantes.Include(l => l.usuarios);
                return View(listado_ayudantes.ToList());
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        public ActionResult Calificacion_administrador(int? id)
        {

            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }



        public ActionResult Editar_administradores(int? id)
        {

            if (Session["UserTelefono"] != null)
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
                ViewBag.telefono = new SelectList(db.usuarios, "telefono", "contraseña", listado_ayudantes.telefono);
                return View(listado_ayudantes);

            }
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // POST: listado_ayudantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar_administradores([Bind(Include = "codigo,descripcion,costo,medioInfo,telefono")] listado_ayudantes listado_ayudantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listado_ayudantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listado_administradores");
            }
            ViewBag.telefono = new SelectList(db.usuarios, "telefono", "contraseña", listado_ayudantes.telefono);
            return View(listado_ayudantes);
        }


        // GET: cliente_ayudante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }


            
        }

        // POST: cliente_ayudante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            listado_ayudantes listado_ayudantes = db.listado_ayudantes.Find(id);
            db.listado_ayudantes.Remove(listado_ayudantes);
            db.SaveChanges();
            return RedirectToAction("Listado_administradores");
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
