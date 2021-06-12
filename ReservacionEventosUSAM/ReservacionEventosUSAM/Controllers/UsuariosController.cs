using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservacionEventosUSAM.Models;
using ReservacionEventosUSAM.Models.CRUD;


namespace ReservacionEventosUSAM.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarUsuarios()
        {
            List<UsuariosMostrar> list = null;
            using (ReservacionEventos2021Entities datos = new ReservacionEventos2021Entities())
            {
                list = (from u in datos.usuarios
                        orderby u.id_usuario
                        select new UsuariosMostrar
                        {
                            id_usuario = u.id_usuario,
                            usuario = u.usuario,
                            contrasena_usuario = u.contrasena_usuario,
                            cod_estado = u.cod_estado,
                            id_rol = u.id_rol
                        }).ToList();
                         
                    
            }

            return View(list);
        }

        public ActionResult AgregarUsuarios()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarUsuarios(UsuarioInsert modelo)
        {
            using (var ddatos = new ReservacionEventos2021Entities())
            {
                usuarios ob = new usuarios();
                ob.id_usuario = modelo.id_usuario;
                ob.usuario = modelo.usuario;
                ob.contrasena_usuario = modelo.contrasena_usuario;
                ob.cod_estado = modelo.cod_estado;
                ob.id_rol = modelo.id_rol;
                
                ddatos.usuarios.Add(ob);
                ddatos.SaveChanges();
            }

            return Redirect(Url.Content("~/Usuarios/ConsultarUsuarios"));
            
        }

        public ActionResult BorrarU(int? id)
        {
            ReservacionEventos2021Entities b = new ReservacionEventos2021Entities();
            usuarios us = b.usuarios.Find(id);
            b.usuarios.Remove(us);
            b.SaveChanges();

            return Redirect(Url.Content("~/Usuarios/ConsultarUsuarios"));

        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ActualizarUsuarios(int? id)
        {
            UsuarioUpdate modelo = new UsuarioUpdate();

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
       public ActionResult ActualizarUsuarios(UsuarioUpdate modelo)
        {
            using (var datos = new ReservacionEventos2021Entities())
            {
                var objuser = datos.usuarios.Find(modelo.id_usuario);

                objuser.id_usuario = modelo.id_usuario ;
                objuser.usuario = modelo.usuario;
                objuser.contrasena_usuario = modelo.contrasena_usuario;
                objuser.cod_estado = modelo.cod_estado;
                objuser.id_rol = modelo.id_rol;

                datos.Entry(objuser).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
            }

            return Redirect(Url.Content("~/Usuarios/ConsultarUsuarios"));
        }
    }
}