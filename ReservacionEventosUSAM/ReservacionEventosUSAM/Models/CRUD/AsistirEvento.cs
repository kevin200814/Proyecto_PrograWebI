using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class AsistirEvento
    {
        public int id_reservacion { get; set; }
        public string nombres_persona { get; set; }
        public string apellidos_persona { get; set; }
        public string telefono_persona { get; set; }
        public string correo_persona { get; set; }
        public string id_tipo_persona { get; set; }
    }
}