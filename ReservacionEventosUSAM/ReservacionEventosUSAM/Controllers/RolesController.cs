
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservacionEventosUSAM.Models.CRUD;
using ReservacionEventosUSAM.Models;

namespace ReservacionEventosUSAM.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarRoles()
        {
            List<RolesMostrar> list = null;
            using (ReservacionEventos2021Entities datos= new ReservacionEventos2021Entities())
            {
                list = (from rol in datos.roles
                        orderby rol.id_rol
                        select new RolesMostrar
                        {
                            id_rol = rol.id_rol,
                            rol = rol.rol
                        }).ToList();
            }

            return View(list);
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AgregarRoles()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarRoles(RolesInsert modelo)
        {
           /* if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            */

            using (var ddatos = new ReservacionEventos2021Entities())
            {
                roles ob = new roles();
                ob.id_rol = modelo.id_rol;
                ob.rol = modelo.rol;
                ddatos.roles.Add(ob);
                ddatos.SaveChanges();
            }

            return Redirect(Url.Content("~/Roles/ConsultarRoles"));
        }

        
        public ActionResult Delete(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            roles rol = db.roles.Find(id);
            db.roles.Remove(rol);
            db.SaveChanges();

            return Redirect(Url.Content("~/Roles/ConsultarRoles"));
        }

        public ActionResult ActualizarRoles(int? id)
        {
            RolesUpdate modelo = new RolesUpdate();

            using (var datos = new ReservacionEventos2021Entities())
            {
                var obrol = datos.roles.Find(id);

                modelo.id_rol = obrol.id_rol;
                modelo.rol = obrol.rol;
            }
            return View(modelo);
           
        }
        [HttpPost]
        public ActionResult ActualizarRoles(RolesUpdate modelo)
        {
            using (var datos = new ReservacionEventos2021Entities())
            {
                var obrol = datos.roles.Find(modelo.id_rol);

                obrol.id_rol= modelo.id_rol ;
                obrol.rol = modelo.rol  ;
                datos.Entry(obrol).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
            }

            return Redirect(Url.Content("~/Roles/ConsultarRoles"));

        }
    }
}