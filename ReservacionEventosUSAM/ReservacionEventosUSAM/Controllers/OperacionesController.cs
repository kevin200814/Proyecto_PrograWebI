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
    public class OperacionesController : Controller
    {
        // GET: Operaciones
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AgregarOperacion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarOperacion(OperacionInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                operaciones obj = new operaciones();
                obj.nomopera = modelo.nomopera;
                obj.codmod = modelo.codmod;
                dbData.operaciones.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Operaciones/ConsultarOperacion"));
        }


        [Autoriza(objOperacion: 4)]
        public ActionResult ConsultarOperacion()
        {
            List<OPERACIONvista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.operaciones
                        orderby d.codopera
                        select new OPERACIONvista
                        {
                            codopera = d.codopera,
                            nomopera = d.nomopera,
                            codmod = (int) d.codmod
                        }).ToList();
            }
            return View(list);
        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarOperacion(int? id)
        {
            OperacionUpdate modelo = new OperacionUpdate();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.operaciones.Find(id);
                modelo.codopera = obj.codopera;
                modelo.codmod = (int)obj.codmod;
                modelo.nomopera = obj.nomopera;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarOperacion(OperacionUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.operaciones.Find(modelo.codopera);
                obj.codopera = modelo.codopera;
                obj.codmod = modelo.codmod;
                obj.nomopera = modelo.nomopera;

                bDatos.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Operaciones/ConsultarOperacion"));
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult Delete(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            operaciones op = db.operaciones.Find(id);
            db.operaciones.Remove(op);
            db.SaveChanges();
            return Redirect(Url.Content("~/Operaciones/ConsultarOperacion"));
        }

    }
}