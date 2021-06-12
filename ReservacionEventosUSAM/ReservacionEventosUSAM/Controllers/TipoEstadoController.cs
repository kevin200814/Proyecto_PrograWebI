
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservacionEventosUSAM.Models;
using ReservacionEventosUSAM.Models.CRUD;

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
            List<MostrarTipoEstado> list = null;

            using (ReservacionEventos2021Entities datos =  new ReservacionEventos2021Entities())
            {
                list = (from e in datos.userState
                        orderby e.cod_estado
                        select new MostrarTipoEstado
                        {
                            cod_estado = e.cod_estado,
                            estado = e.estado
                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AgregarTipoEstado()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarTipoEstado(TipoEstadoInsert modelo)
        {
            using (var ddatos = new ReservacionEventos2021Entities())
            {
                userState obj = new userState();
                obj.cod_estado = modelo.cod_estado;
                obj.estado = modelo.estado;
                ddatos.userState.Add(obj);
                ddatos.SaveChanges();
            }

            return Redirect(Url.Content("~/TipoEstado/ConsultarTipoEstado"));
            
        }

        public ActionResult BorrarE (int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();

            userState estado = db.userState.Find(id);
            db.userState.Remove(estado);
            db.SaveChanges();

            return Redirect(Url.Content("~/TipoEstado/ConsultarTipoEstado"));
        }

        public ActionResult ActualizarTipoEstado(int? id)
        {
            TipoEstadoUpdate modelo = new TipoEstadoUpdate();

            using (var datos = new ReservacionEventos2021Entities())
            {
                var objestado = datos.userState.Find(id);
                modelo.cod_estado = objestado.cod_estado;
                modelo.estado = objestado.estado;

            }
            return View(modelo);
        }

        [HttpPost]
        public ActionResult ActualizarTipoEstado(TipoEstadoUpdate modelo)
        {
         
            using (var datos = new ReservacionEventos2021Entities())
            {
                var objestado = datos.userState.Find(modelo.cod_estado);
                objestado.cod_estado= modelo.cod_estado ;
                objestado.estado =modelo.estado ;

                datos.Entry(objestado).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();

            }
            return Redirect(Url.Content("~/TipoEstado/ConsultarTipoEstado"));
        }
    }
}