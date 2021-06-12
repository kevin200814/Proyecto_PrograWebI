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
    public class LugaresController : Controller
    {
        // GET: Lugares
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AgregarLocal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarLugares(LocalcrudInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                local_evento obj = new local_evento();
                obj.nombre_local = modelo.nombre_local;
                dbData.local_evento.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Lugares/ConsultarLugares"));
        }

        [Autoriza(objOperacion: 4)]
        public ActionResult ConsultarLugares()
        {
            List<LOCALvista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.local_evento
                        orderby d.id_local
                        select new LOCALvista
                        {
                            id_local = d.id_local,
                            nombre_local = d.nombre_local
                        }).ToList();
            }
            return View(list);
        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarLugares(int? id)
        {
            LocalcrudUpdate modelo = new LocalcrudUpdate();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.local_evento.Find(id);

                modelo.id_local = obj.id_local;
                modelo.nombre_local = obj.nombre_local;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarLugares(LocalcrudUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.local_evento.Find(modelo.id_local);
                obj.id_local = modelo.id_local;
                obj.nombre_local = modelo.nombre_local;

                bDatos.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Lugares/ConsultarLugares"));
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult Delete(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            local_evento mod = db.local_evento.Find(id);
            db.local_evento.Remove(mod);
            db.SaveChanges();
            return Redirect(Url.Content("~/Lugares/ConsultarLugares"));
        }
    }
}