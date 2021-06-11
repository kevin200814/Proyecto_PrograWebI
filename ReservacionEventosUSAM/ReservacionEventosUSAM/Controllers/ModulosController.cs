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
    public class ModulosController : Controller
    {
        // GET: Modulos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AgregarModulo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarModulo(Moduloscrud modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                modulos obj = new modulos();
                obj.nombre = modelo.nombre;
                obj.codmod = modelo.codmod;
                dbData.modulos.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Modulos/ConsultarModulos"));
        }

        [Autoriza(objOperacion: 4)]
        public ActionResult ConsultarModulos()
        {
            List<MODULOSvista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.modulos
                        orderby d.codmod
                        select new MODULOSvista
                        {
                            codmod = d.codmod,
                            nombre = d.nombre
                        }).ToList();
            }
            return View(list);
        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarModulo(int? id)
        {
            ModuloUpdate modelo = new ModuloUpdate();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.modulos.Find(id);

                modelo.codmod = obj.codmod;
                modelo.nombre = obj.nombre;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarModulo(ModuloUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.modulos.Find(modelo.codmod);
                obj.codmod = modelo.codmod;
                obj.nombre = modelo.nombre;

                bDatos.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Modulos/ConsultarModulos"));
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult Delete(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            modulos mod = db.modulos.Find(id);
            db.modulos.Remove(mod);
            db.SaveChanges();
            return Redirect(Url.Content("~/Modulos/ConsultarModulos"));
        }
    }
}