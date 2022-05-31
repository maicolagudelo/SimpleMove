using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using SimpleMove.Models;

namespace SimpleMove.Controllers
{
    public class LoginViewController : Controller
    {
        private simplemove db = new simplemove();

        // GET: LoginView
        public ActionResult login()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuarios objUser, string token)
        {



            if (ModelState.IsValid)
            {
                using (simplemove db = new simplemove())
                {
                    var obj = db.usuarios.Where(a => a.telefono.Equals(objUser.telefono) && a.contraseña.Equals(objUser.contraseña)).FirstOrDefault();
                   
                    Respuesta user = new Respuesta();

                    var tipo_admin = db.usuarios.Where(a=> objUser.tipo_usuario.Equals(a.tipo_usuario == 1));
                    var tipo_clie = db.usuarios.Where(a => objUser.tipo_usuario.Equals(a.tipo_usuario == 2));
                    var tipo_ayu = db.usuarios.Where(a => objUser.tipo_usuario.Equals(a.tipo_usuario == 3));
                    var tipo_con = db.usuarios.Where(a => objUser.tipo_usuario.Equals(a.tipo_usuario == 4));

                    if (obj != null)
                    {
                        Session["UserTelefono"] = obj.telefono.ToString();
                        Session["UserNombre"] = obj.nombre.ToString();
                        Session["UserRol"]=obj.tipo_usuario.ToString();
                        user.Token = token;


                        if (obj.tipo_usuario == 1)
                        {
                            return RedirectToAction("Usuario", "usuarios");
                        }
                        else if (obj.tipo_usuario == 2)
                        {
                            return RedirectToAction("Listado", "listado_ayudantes");
                        }
                        else if (obj.tipo_usuario == 3)
                        {
                            return RedirectToAction("Listado_ayudante", "listado_ayudantes");
                        }
                        else if (obj.tipo_usuario == 4)
                        {
                            return RedirectToAction("Listado_conductores", "Listado_conductores");
                        }

                    }
                   
                }
            }
            return View(objUser);
        }

        // GET: usuarios/Create
        public ActionResult Registro()
        {
            ViewBag.tipo_usuario = new SelectList(db.tipo_usuarios, "tipo_usuario", "usuario");
            return View();
        }

        // POST: usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro([Bind(Include = "telefono,contraseña,tipo_usuario,nombre,apellido,direccion")] usuarios usuarios)
        {


            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("login");
            }


            ViewBag.tipo_usuario = new SelectList(db.tipo_usuarios, "tipo_usuario", "usuario", usuarios.tipo_usuario);
            return View(usuarios);
        }

    }
}