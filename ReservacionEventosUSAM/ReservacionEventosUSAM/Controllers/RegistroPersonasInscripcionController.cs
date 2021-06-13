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
    public class RegistroPersonasInscripcionController : Controller
    {
        // GET: RegistroPersonasInscripcion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarPersonasEvento(int? id)
        {
            List<RPIvista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.registro_inscripcion
                        join e in bDatos.reservacion_evento on d.id_reservacion equals e.id_reservacion
                        join f in bDatos.tipo_persona on d.id_tipo_persona equals f.id_tipo_persona
                        orderby d.id_reservacion
                        where d.id_reservacion == id
                        select new RPIvista
                        {
                            id_inscripcion = d.id_inscripcion,
                            titulo_evento = e.titulo_evento,
                            nombres_persona = d.nombres_persona,
                            apellidos_persona = d.apellidos_persona,
                            telefono_persona = d.telefono_persona,
                            correo_persona = d.correo_persona,
                            tipo_persona = f.tipo_persona1

                        }).ToList();


            }
            return View(list);

        }

    }
}