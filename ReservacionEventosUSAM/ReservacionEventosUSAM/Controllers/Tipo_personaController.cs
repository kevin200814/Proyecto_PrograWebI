using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservacionEventosUSAM.Controllers
{
    public class Tipo_personaController : Controller
    {
        // GET: Tipo_persona
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarTipoPersona()
        {
            return View();
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}