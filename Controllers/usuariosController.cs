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
    public class usuariosController : Controller
    {
        private simplemove db = new simplemove();

        // GET: usuarios
        
        public ActionResult Usuario()
        {
            if (Session["UserTelefono"] != null)
            {
                var usuarios = db.usuarios.Include(u => u.tipo_usuarios);
                return View(usuarios.ToList());
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }
        // GET: usuarios/Details/5
        public ActionResult Details(long? id)
        {
            if (Session["UserTelefono"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                usuarios usuarios = db.usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

            
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            if (Session["UserTelefono"] != null)
            {
                ViewBag.tipo_usuario = new SelectList(db.tipo_usuarios, "tipo_usuario", "usuario");
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        // POST: usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "telefono,contraseña,tipo_usuario,nombre,apellido,direccion")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Usuario");
            }
            

            ViewBag.tipo_usuario = new SelectList(db.tipo_usuarios, "tipo_usuario", "usuario", usuarios.tipo_usuario);
            return View(usuarios);
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (Session["UserTelefono"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                usuarios usuarios = db.usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                ViewBag.tipo_usuario = new SelectList(db.tipo_usuarios, "tipo_usuario", "usuario", usuarios.tipo_usuario);
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        // POST: usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "telefono,contraseña,tipo_usuario,nombre,apellido,direccion")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Usuario");
            }
            ViewBag.tipo_usuario = new SelectList(db.tipo_usuarios, "tipo_usuario", "usuario", usuarios.tipo_usuario);
            return View(usuarios);
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(long? id)
        {

            if (Session["UserTelefono"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                usuarios usuarios = db.usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            db.usuarios.Remove(usuarios);
            db.SaveChanges();
            return RedirectToAction("Usuario");
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
