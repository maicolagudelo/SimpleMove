using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMove.Controllers
{
    public class cerrarController : Controller
    {
        // GET: cerrar
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("login", "LoginView");
        }
    }
}