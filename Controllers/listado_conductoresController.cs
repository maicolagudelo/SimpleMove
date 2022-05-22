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
    public class listado_conductoresController : Controller
    {
        private simplemove db = new simplemove();

        // cliente
        public ActionResult Listado()
        {
            if (Session["UserTelefono"] != null)
            {
                var listado_conductores = db.listado_conductores.Include(l => l.usuarios);
                return View(listado_conductores.ToList());
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }


        public ActionResult Calificacion(int? id)
        {

            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }


        // conductores
        public ActionResult Listado_conductores()
        {
            if (Session["UserTelefono"] != null)
            {
                var listado_conductores = db.listado_conductores.Include(l => l.usuarios);
                return View(listado_conductores.ToList());
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }



        public ActionResult Calificacion_conductores(int? id)
        {

            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }
            

        }





        // GET: listado_conductores/Create
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

        // POST: listado_conductores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "codigo,descripcion,costo,medioInfo,capacidad,telefono")] listado_conductores listado_conductores)
        {
            if (ModelState.IsValid)
            {
                db.listado_conductores.Add(listado_conductores);
                db.SaveChanges();
                return RedirectToAction("Listado_conductores");
            }

            ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre", listado_conductores.telefono);
            return View(listado_conductores);
        }


        // GET: listado_conductores/Edit/5
        public ActionResult Editar(int? id)
        {

            if (Session["UserTelefono"] != null)
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
                ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre", listado_conductores.telefono);
                return View(listado_conductores);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        // POST: listado_conductores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codigo,descripcion,costo,medioInfo,capacidad,telefono")] listado_conductores listado_conductores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listado_conductores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Listado_conductores");
            }
            ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre", listado_conductores.telefono);
            return View(listado_conductores);
        }

        public ActionResult Delete_conductores(int? id)
        {
            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // POST: listado_conductores/Delete/5
        [HttpPost, ActionName("Delete_conductores")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_conductores(int id)
        {
            if (Session["UserTelefono"] != null)
            {
                listado_conductores listado_conductores = db.listado_conductores.Find(id);
                db.listado_conductores.Remove(listado_conductores);
                db.SaveChanges();
                return RedirectToAction("Listado_conductores");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }







        //administrador 

        public ActionResult Listado_administradores()
        {
            if (Session["UserTelefono"] != null)
            {
                var listado_conductores = db.listado_conductores.Include(l => l.usuarios);
                return View(listado_conductores.ToList());
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        public ActionResult Calificacion_administradores(int? id)
        {
            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // GET: listado_conductores/Edit/5
        public ActionResult Editar_administradores(int? id)
        {
            if (Session["UserTelefono"] != null)
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
                ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre", listado_conductores.telefono);
                return View(listado_conductores);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // POST: listado_conductores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar_administradores([Bind(Include = "codigo,descripcion,costo,medioInfo,capacidad,telefono")] listado_conductores listado_conductores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listado_conductores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Listado_administradores");
            }
            ViewBag.telefono = new SelectList(db.usuarios, "telefono", "nombre", listado_conductores.telefono);
            return View(listado_conductores);
        }



        // GET: listado_conductores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserTelefono"] != null)
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
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // POST: listado_conductores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserTelefono"] != null)
            {
                listado_conductores listado_conductores = db.listado_conductores.Find(id);
                db.listado_conductores.Remove(listado_conductores);
                db.SaveChanges();
                return RedirectToAction("Listado_administradores");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

            
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
