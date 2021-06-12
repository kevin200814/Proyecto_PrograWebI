using ReservacionEventosUSAM.Filter;
using ReservacionEventosUSAM.Models.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservacionEventosUSAM.Controllers
{
    public class RegistrosController : Controller
    {
        // GET: Registros
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarRegistro()
        {
            List<RegistroInscripcionVista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.registro_inscripcion
                        orderby d.id_inscripcion
                        select new RegistroInscripcionVista
                        {
                            id_inscripcion = d.id_inscripcion,
                            id_reservacion = d.id_reservacion,
                            nombres_persona = d.nombres_persona,
                            apellidos_persona = d.apellidos_persona,
                            telefono_persona = d.telefono_persona,
                            correo_persona = d.correo_persona,
                            id_tipo_persona = d.id_tipo_persona
                        }).ToList();
            }
            return View(list);
        }

        public ActionResult AgregarRegistro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarRegistro(RegistroInscripcionInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                registro_inscripcion obj = new registro_inscripcion();
                obj.id_reservacion = modelo.id_reservacion;
                obj.nombres_persona = modelo.nombres_persona;
                obj.apellidos_persona = modelo.apellidos_persona;
                obj.telefono_persona = modelo.telefono_persona;
                obj.correo_persona = modelo.correo_persona;
                obj.id_tipo_persona = modelo.id_tipo_persona;
                dbData.registro_inscripcion.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Registros/ConsultarRegistro"));

        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarRegistro(int? id)
        {
            registro_inscripcion modelo = new registro_inscripcion();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var objPerso = bDatos.registro_inscripcion.Find(id);
                modelo.id_inscripcion = objPerso.id_inscripcion;
                modelo.id_reservacion = objPerso.id_reservacion;
                modelo.nombres_persona = objPerso.nombres_persona;
                modelo.apellidos_persona = objPerso.apellidos_persona;
                modelo.telefono_persona = objPerso.telefono_persona;
                modelo.correo_persona = objPerso.correo_persona;
                modelo.id_tipo_persona = objPerso.id_tipo_persona;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarRegistro(RegistroInscripcionUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var objEven = bDatos.registro_inscripcion.Find(modelo.id_inscripcion);
                objEven.id_inscripcion = modelo.id_inscripcion;
                objEven.id_reservacion = modelo.id_reservacion;
                objEven.nombres_persona = modelo.nombres_persona;
                objEven.apellidos_persona = modelo.apellidos_persona;
                objEven.telefono_persona = modelo.telefono_persona;
                objEven.correo_persona = modelo.correo_persona;
                objEven.id_tipo_persona = modelo.id_tipo_persona;

                bDatos.Entry(objEven).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Registros/ConsultarRegistro"));
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult DeleteTipoRegistro(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            registro_inscripcion op = db.registro_inscripcion.Find(id);
            db.registro_inscripcion.Remove(op);
            db.SaveChanges();
            return Redirect(Url.Content("~/Registros/ConsultarRegistro"));
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}