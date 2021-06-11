using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservacionEventosUSAM.Controllers
{
    public class Tipo_eventoController : Controller
    {
        // GET: Tipo_evento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarTipoEvento()
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