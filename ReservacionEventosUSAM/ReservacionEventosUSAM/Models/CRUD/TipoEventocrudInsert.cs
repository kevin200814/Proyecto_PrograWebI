using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class TipoEventocrudInsert
    {
        public int id_tipo_evento { get; set; }
        public string nombre_evento { get; set; }
        public string descripcion_evento { get; set; }
    }

    public class TipoEventocrudUpdate
    {
        public int id_tipo_evento { get; set; }
        public string nombre_evento { get; set; }
        public string descripcion_evento { get; set; }
    }
}