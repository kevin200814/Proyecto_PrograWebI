using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservacionEventosUSAM.Models;
using ReservacionEventosUSAM.Models.CRUD;

namespace ReservacionEventosUSAM.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile(int? id)
        {
            UsuarioPassUpdate modelo = new UsuarioPassUpdate();

            using (var datos = new ReservacionEventos2021Entities())
            {
                var objuser = datos.usuarios.Find(id);

                modelo.id_usuario = objuser.id_usuario;
                modelo.usuario = objuser.usuario;
                modelo.contrasena_usuario = objuser.contrasena_usuario;
                modelo.cod_estado = (int)objuser.cod_estado;
                modelo.id_rol = (int)objuser.id_rol;

            }
            return View(modelo);
        }

        [HttpPost]
        public ActionResult ActualizarMisDatos(UsuarioPassUpdate modelo)
        {
            using (var datos = new ReservacionEventos2021Entities())
            {
                var objuser = datos.usuarios.Find(modelo.id_usuario);

                objuser.id_usuario = modelo.id_usuario;
                objuser.usuario = modelo.usuario;
                objuser.contrasena_usuario = modelo.contrasena_usuario;
                objuser.cod_estado = modelo.cod_estado;
                objuser.id_rol = modelo.id_rol;

                datos.Entry(objuser).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
            }

            return Redirect(Url.Content("~/Home/"));
        }
    }
}