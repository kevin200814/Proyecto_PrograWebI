using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class ROL_OPERAvista
    {
        public int id_rol_opera { get; set; }
        public int id_rol { get; set; }
        public int codopera { get; set; }

        /*Tabla roles*/
        public string  rol { get; set; }

        /*Tabla operaciones*/
        public string nomopera { get; set; }
    }
}