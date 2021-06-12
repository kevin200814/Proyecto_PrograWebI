using ReservacionEventosUSAM.Filter;
using ReservacionEventosUSAM.Models.CRUD;
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


        public ActionResult AgregarTipoPersona()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarTipoPersona(TipoPersonaInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                tipo_persona obj = new tipo_persona();
                obj.tipo_persona1 = modelo.tipo_persona;
                obj.costo_pago_evento = modelo.costo_pago_evento;
                dbData.tipo_persona.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Tipo_persona/ConsultarTipoPersona"));
            
        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarTipoPersona(int? id)
        {
            TipoPersonaUpdate modelo = new TipoPersonaUpdate();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var objPerso = bDatos.tipo_persona.Find(id);
                modelo.id_tipo_persona = objPerso.id_tipo_persona;
                modelo.tipo_persona = objPerso.tipo_persona1;
                modelo.costo_pago_evento = objPerso.costo_pago_evento;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarTipoPersona(TipoPersonaUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var objPerso = bDatos.tipo_persona.Find(modelo.id_tipo_persona);
                objPerso.id_tipo_persona = modelo.id_tipo_persona;
                objPerso.tipo_persona1 = modelo.tipo_persona;
                objPerso.costo_pago_evento = modelo.costo_pago_evento;

                bDatos.Entry(objPerso).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Tipo_persona/ConsultarTipoPersona"));
        }

        public ActionResult ConsultarTipoPersona()
        {
            List<TipoPersonaVista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.tipo_persona
                        orderby d.id_tipo_persona
                        select new TipoPersonaVista
                        {
                            id_tipo_persona = d.id_tipo_persona,
                            tipo_persona = d.tipo_persona1,
                            costo_pago_evento = d.costo_pago_evento
                        }).ToList();
            }
            return View(list);
            
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult DeleteTipoPersona(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            tipo_persona op = db.tipo_persona.Find(id);
            db.tipo_persona.Remove(op);
            db.SaveChanges();
            return Redirect(Url.Content("~/Tipo_persona/ConsultarTipoPersona"));
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}