using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMove.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult index_cliente()
        {
            if (Session["UserTelefono"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        
        public ActionResult index_ayudante(LoginViewController login )
        {
            if (Session["UserTelefono"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        public ActionResult index_conductor()
        {

            if (Session["UserTelefono"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }

        public ActionResult index_administrador()
        {

            if (Session["UserTelefono"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }
    }
}