using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservacionEventosUSAM.Filter;
using ReservacionEventosUSAM.Models.CRUD;
using ReservacionEventosUSAM.Models;

namespace ReservacionEventosUSAM.Controllers
{
    public class Tipo_eventoController : Controller
    {
        // GET: Tipo_evento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AgregarTipoEvento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarTipoEvento(TipoEventocrudInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                tipo_evento obj = new tipo_evento();
                obj.nombre_evento = modelo.nombre_evento;
                obj.descripcion_evento = modelo.descripcion_evento;
                dbData.tipo_evento.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Tipo_evento/ConsultarTipoEvento"));
        }

        [Autoriza(objOperacion: 4)]
        public ActionResult ConsultarTipoEvento()
        {
            List<TIPOEVENTOvista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.tipo_evento
                        orderby d.id_tipo_evento
                        select new TIPOEVENTOvista
                        {
                            id_tipo_evento = d.id_tipo_evento,
                            nombre_evento = d.nombre_evento,
                            descripcion_evento = d.descripcion_evento
                        }).ToList();
            }
            return View(list);
        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarTipoEvento(int? id)
        {
            TipoEventocrudUpdate modelo = new TipoEventocrudUpdate();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.tipo_evento.Find(id);

                modelo.id_tipo_evento = obj.id_tipo_evento;
                modelo.nombre_evento = obj.nombre_evento;
                modelo.descripcion_evento = obj.descripcion_evento;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarTipoEvento(TipoEventocrudUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.tipo_evento.Find(modelo.id_tipo_evento);
                obj.id_tipo_evento = modelo.id_tipo_evento;
                obj.nombre_evento = modelo.nombre_evento;
                obj.descripcion_evento = modelo.descripcion_evento;

                bDatos.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Tipo_evento/ConsultarTipoEvento"));
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult Delete(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            tipo_evento mod = db.tipo_evento.Find(id);
            db.tipo_evento.Remove(mod);
            db.SaveChanges();
            return Redirect(Url.Content("~/Tipo_evento/ConsultarTipoEvento"));
        }

    }
}