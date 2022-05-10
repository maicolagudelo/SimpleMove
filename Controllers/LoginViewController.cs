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
        // GET: LoginView
        public ActionResult login()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuarios objUser)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                using (simplemove db = new simplemove())
                {
                    var obj = db.usuarios.Where(a => a.telefono.Equals(objUser.telefono) && a.contraseña.Equals(objUser.contraseña)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserTelefono"] = obj.telefono.ToString();
                        Session["UserNombre"] = obj.nombre.ToString();
                        return RedirectToAction("index_ayudante", "Home");
                    }
                    else
                    {
                        msg = "Usuario o Contraseña incorrecta";
                       ViewBag.mensaje = msg;
                        return View();
                    }
                }
            }
            return View(objUser);
        }
    }
}