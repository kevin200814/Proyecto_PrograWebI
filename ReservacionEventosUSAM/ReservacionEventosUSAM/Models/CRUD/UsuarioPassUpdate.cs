using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class UsuarioPassUpdate
    {
        public int id_usuario { get; set; }

        public string usuario { get; set; }

        public string contrasena_usuario { get; set; }
        public int cod_estado { get; set; }
        public int id_rol { get; set; }
    }
}