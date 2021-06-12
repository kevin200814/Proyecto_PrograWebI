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
    public class EventosController : Controller
    {
        // GET: Eventos
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AgregarEvento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEvento(EventocrudInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                reservacion_evento obj = new reservacion_evento();
                obj.titulo_evento = modelo.titulo_evento;
                obj.fecha_evento = modelo.fecha_evento;
                obj.inicio_hora_evento = modelo.inicio_hora_evento;
                obj.fin_hora_evento = modelo.fin_hora_evento;
                obj.duracion_evento = modelo.titulo_evento;
                obj.descripcion_evento = modelo.titulo_evento;
                obj.id_tipo_evento = (int)modelo.id_tipo_evento;
                obj.id_persona = (int)modelo.id_persona;
                obj.id_local = (int)modelo.id_local;
                obj.estado_evento = modelo.estado_evento;
                obj.tipo_persona = modelo.tipo_persona;
                dbData.reservacion_evento.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Eventos/ConsultarEventos"));
        }

        [Autoriza(objOperacion: 4)]
        public ActionResult ConsultarEventos()
        {
            List<EVENTOvista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.reservacion_evento
                        orderby d.id_reservacion
                        select new EVENTOvista
                        {
                            id_reservacion = d.id_reservacion,
                            titulo_evento = d.titulo_evento,
                            fecha_evento = d.fecha_evento,
                            inicio_hora_evento = d.inicio_hora_evento,
                            fin_hora_evento = d.fin_hora_evento,
                            duracion_evento = d.duracion_evento,
                            descripcion_evento = d.descripcion_evento,
                            id_tipo_evento = d.id_tipo_evento,
                            id_persona = d.id_persona,
                            id_local = d.id_local,
                            estado_evento = d.estado_evento,
                            tipo_persona = d.tipo_persona
                        }).ToList();
            }
            return View(list);
        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarEvento(int? id)
        {
            EventocrudUpdate modelo = new EventocrudUpdate();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.reservacion_evento.Find(id);

                modelo.id_reservacion = obj.id_reservacion;
                modelo.titulo_evento = obj.titulo_evento;
                modelo.fecha_evento = obj.fecha_evento;
                modelo.inicio_hora_evento = obj.inicio_hora_evento;
                modelo.fin_hora_evento = obj.fin_hora_evento;
                modelo.duracion_evento = obj.duracion_evento;
                modelo.descripcion_evento = obj.descripcion_evento;
                modelo.id_tipo_evento = (int)obj.id_tipo_evento;
                modelo.id_persona = (int)obj.id_persona;
                modelo.id_local = (int)obj.id_local;
                modelo.estado_evento = obj.estado_evento;
                modelo.tipo_persona = obj.tipo_persona;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarEvento(EventocrudUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.reservacion_evento.Find(modelo.id_reservacion);
                obj.id_reservacion = modelo.id_reservacion;
                obj.titulo_evento = modelo.titulo_evento;
                obj.fecha_evento = modelo.fecha_evento;
                obj.inicio_hora_evento = modelo.inicio_hora_evento;
                obj.fin_hora_evento = modelo.fin_hora_evento;
                obj.duracion_evento = modelo.duracion_evento;
                obj.descripcion_evento = modelo.descripcion_evento;
                obj.id_tipo_evento = (int)modelo.id_tipo_evento;
                obj.id_persona = (int)modelo.id_persona;
                obj.id_local = (int)modelo.id_local;
                obj.estado_evento = modelo.estado_evento;
                obj.tipo_persona = modelo.tipo_persona;

                bDatos.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Eventos/ConsultarEventos"));
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult Delete(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            reservacion_evento mod = db.reservacion_evento.Find(id);
            db.reservacion_evento.Remove(mod);
            db.SaveChanges();
            return Redirect(Url.Content("~/Eventos/ConsultarEventos"));
        }
    }
}