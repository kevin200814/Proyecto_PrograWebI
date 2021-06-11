using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservacionEventosUSAM.Controllers
{
    public class TipoEstadoController : Controller
    {
        // GET: TipoEstado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarTipoEstado()
        {
            return View();
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}