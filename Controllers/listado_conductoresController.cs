using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
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
        public ActionResult Crear([Bind(Include = "codigo,descripcion,costo,medioInfo,capacidad,telefono,estado,img")] listado_conductores listado_conductores)
        {
            HttpPostedFileBase FileBase = Request.Files[0];

            WebImage image = new WebImage(FileBase.InputStream);

            listado_conductores.img = image.GetBytes();

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
        public ActionResult Editar([Bind(Include = "codigo,descripcion,costo,medioInfo,capacidad,telefono,estado,img")] listado_conductores listado_conductores)
        {
            byte[] imagenactual = null;

            HttpPostedFileBase FileBase = Request.Files[0];

            if (FileBase == null)
            {
                imagenactual = db.listado_ayudantes.SingleOrDefault(t => t.codigo == listado_conductores.codigo).img;
            }
            else
            {
                WebImage image = new WebImage(FileBase.InputStream);

                listado_conductores.img = image.GetBytes();
            }

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
        public ActionResult Editar_administradores([Bind(Include = "codigo,descripcion,costo,medioInfo,capacidad,telefono,estado,img")] listado_conductores listado_conductores)
        {
            byte[] imagenactual = null;

            HttpPostedFileBase FileBase = Request.Files[0];

            if (FileBase == null)
            {
                imagenactual = db.listado_ayudantes.SingleOrDefault(t => t.codigo == listado_conductores.codigo).img;
            }
            else
            {
                WebImage image = new WebImage(FileBase.InputStream);

                listado_conductores.img = image.GetBytes();
            }

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


        public ActionResult getImage(int codigo)
        {
            listado_conductores imagen = db.listado_conductores.Find(codigo);
            byte[] byteImage = imagen.img;

            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;


            return File(memoryStream, "image/jpg");

        }

    }
}
