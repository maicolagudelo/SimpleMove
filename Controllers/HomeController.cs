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
            
            return View();
        }

        public ActionResult index_ayudante()
        {

            return View();
        }

        public ActionResult index_conductor()
        {

            return View();
        }

        public ActionResult index_administrador()
        {

            return View();
        }
    }
}