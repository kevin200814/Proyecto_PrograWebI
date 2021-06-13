using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class TipoPresonaSelect
    {

        public int id_tipo_persona { get; set; }
        public string tipo_persona { get; set; }
        public decimal costo_pago_evento { get; set; }
    }
}