using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservacionEventosUSAM.Models;
using ReservacionEventosUSAM.Models.CRUD;

namespace ReservacionEventosUSAM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ingresar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Ingresar(string user, string password)
        {
            try
            {
                using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
                {
                    var usr = (from d in bDatos.usuarios
                               where d.usuario == user.Trim() &&
                               d.contrasena_usuario == password.Trim() &&
                               d.cod_estado == 1
                               select d).FirstOrDefault();
                    if (usr == null)
                    {
                        ViewBag.Error = "Password y user No existe";
                        return View();
                    }
                    else
                    {
                        Session["Id"] = usr.id_usuario;
                        Session["Usuario"] = usr;
                        Session["Usr"] = user;
                    }
                    return RedirectToAction("ConsultarEventos", "Eventos");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }

        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}