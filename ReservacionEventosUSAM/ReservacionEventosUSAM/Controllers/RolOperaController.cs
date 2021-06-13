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
    public class RolOperaController : Controller
    {
        // GET: RolOpera
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AgregarRolOpera()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarRolOpera(Rol_OperacrudInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var dbData = new ReservacionEventos2021Entities())
            {
                rol_opera obj = new rol_opera();
                obj.id_rol_opera = modelo.id_rol_opera;
                obj.id_rol = modelo.id_rol;
                obj.codopera = modelo.codopera;
                dbData.rol_opera.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/RolOpera/ConsultarRolOpera"));
        }


        [Autoriza(objOperacion: 4)]
        public ActionResult ConsultarRolOpera()
        {
            List<ROL_OPERAvista> list = null;
            using (ReservacionEventos2021Entities bDatos = new ReservacionEventos2021Entities())
            {
                list = (from d in bDatos.rol_opera
                        join e in bDatos.roles on d.id_rol equals e.id_rol
                        join f in bDatos.operaciones on d.codopera equals f.codopera
                        orderby d.id_rol_opera 
                        select new ROL_OPERAvista
                        {
                            id_rol_opera = d.id_rol_opera,
                            id_rol = d.id_rol,
                            codopera = (int)d.codopera,
                            rol = e.rol,
                            nomopera = f.nomopera
                        }).ToList();
            }
            return View(list);
        }

        [Autoriza(objOperacion: 3)]
        public ActionResult ActualizarRolOpera(int? id)
        {
            Rol_OperacrudUpdate modelo = new Rol_OperacrudUpdate();

            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.rol_opera.Find(id);
                modelo.id_rol_opera = obj.id_rol_opera;
                modelo.id_rol = obj.id_rol;
                modelo.codopera = obj.codopera;
            }
            return View(modelo);
        }

        [Autoriza(objOperacion: 3)]
        [HttpPost]
        public ActionResult ActualizarRolOpera(Rol_OperacrudUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            using (var bDatos = new ReservacionEventos2021Entities())
            {
                var obj = bDatos.rol_opera.Find(modelo.id_rol_opera);
                obj.id_rol_opera = modelo.id_rol_opera;
                obj.id_rol = modelo.id_rol;
                obj.codopera = modelo.codopera;

                bDatos.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/RolOpera/ConsultarRolOpera"));
        }

        [Autoriza(objOperacion: 2)]
        public ActionResult Delete(int? id)
        {
            ReservacionEventos2021Entities db = new ReservacionEventos2021Entities();
            rol_opera op = db.rol_opera.Find(id);
            db.rol_opera.Remove(op);
            db.SaveChanges();
            return Redirect(Url.Content("~/RolOpera/ConsultarRolOpera"));
        }

    }
}