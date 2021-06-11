using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservacionEventosUSAM.Models;
using ReservacionEventosUSAM.Models.CRUD;

namespace ReservacionEventosUSAM.Filter
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Autoriza : AuthorizeAttribute
    {
        private usuarios objUser;
        private ReservacionEventos2021Entities objDatos = new ReservacionEventos2021Entities();
        private int objOperacion;

        public Autoriza(int objOperacion = 0)
        {
            this.objOperacion = objOperacion;
        }

        public string getNombreOperacion(int CodOpra)
        {
            var nOper = from o in objDatos.operaciones
                        where o.codopera == CodOpra
                        select o.nomopera;
            String nombOperac;
            try
            {
                nombOperac = nOper.First();

            }
            catch
            {
                nombOperac = "";
            }
            return nombOperac;
        }

        public string getNombreModulo(int? CodMod)
        {
            var nModulo = from modulo in objDatos.modulos
                          where modulo.codmod == CodMod
                          select modulo.nombre;
            String nombModulo;
            try
            {
                nombModulo = nModulo.First();

            }
            catch
            {
                nombModulo = "";
            }
            return nombModulo;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                objUser = (usuarios)HttpContext.Current.Session["Usuario"];
                var oprLst = from d in objDatos.rol_opera
                             where d.id_rol == objUser.id_rol &&
                                   d.id_rol_opera == objOperacion
                             select d;

                if (oprLst.ToList().Count() == 0)
                {
                    var objOpr = objDatos.operaciones.Find(objOperacion);
                    int? codModulo = objOpr.codmod;
                    nombreOperacion = getNombreOperacion(objOperacion);
                    nombreModulo = getNombreModulo(codModulo);
                    filterContext.Result = new RedirectResult("~/Error/noAutorizado?operacion=" + nombreOperacion + ",Modulo=" + nombreModulo + ",msjErrorExcp='falla'"); //envia a login
                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Error/noAutorizado?operacion=" + nombreOperacion + ",Modulo=" + nombreModulo + ",msjErrorExcp='falla'"); //envia a login
            }

        }


    }
}