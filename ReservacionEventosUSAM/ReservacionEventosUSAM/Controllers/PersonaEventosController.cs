using ReservacionEventosUSAM.Filter;
using ReservacionEventosUSAM.Models.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservacionEventosUSAM.Controllers
{
    public class PersonaEventosController : Controller
    {
        // GET: PersonaEventos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarPersonaEvento()
        {
            List<PersonaEventosVista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.persona_eventos
                        orderby d.id_persona
                        select new PersonaEventosVista
                        {
                            id_persona = d.id_persona,
                            nombres_persona = d.nombres_persona,
                            apellidos_persona = d.apellidos_persona,
                            profesion_persona = d.profesion_persona

                        }).ToList();
            }
            return View(list);
        }

        public ActionResult AgregarPersonaEvento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPersonaEvento(PersonaEventosInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                persona_eventos obj = new persona_eventos();
                obj.nombres_persona = modelo.nombres_persona;
                obj.apellidos_persona = modelo.apellidos_persona;
                obj.profesion_persona = modelo.profesion_persona;
                dbData.persona_eventos.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/PersonaEventos/ConsultarPersonaEvento"));

        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarPersonaEvento(int? id)
        {

            PersonaEventosUpdate modelo = new PersonaEventosUpdate();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var objPerso = bDatos.persona_eventos.Find(id);
                modelo.id_persona = objPerso.id_persona;
                modelo.nombres_persona = objPerso.nombres_persona;
                modelo.apellidos_persona = objPerso.apellidos_persona;
                modelo.profesion_persona = objPerso.profesion_persona;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarPersonaEvento(PersonaEventosUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var objPerso = bDatos.persona_eventos.Find(modelo.id_persona);
                objPerso.id_persona = modelo.id_persona;
                objPerso.nombres_persona = modelo.nombres_persona;
                objPerso.apellidos_persona = modelo.apellidos_persona;
                objPerso.profesion_persona = modelo.profesion_persona;

                bDatos.Entry(objPerso).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/PersonaEventos/ConsultarPersonaEvento"));
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult DeletePersonaEvento(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            persona_eventos op = db.persona_eventos.Find(id);
            db.persona_eventos.Remove(op);
            db.SaveChanges();
            return Redirect(Url.Content("~/PersonaEventos/ConsultarPersonaEvento"));
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}