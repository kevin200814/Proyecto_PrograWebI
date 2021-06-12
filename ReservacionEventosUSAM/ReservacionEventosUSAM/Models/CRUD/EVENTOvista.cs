using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class EVENTOvista
    {
        public int id_reservacion { get; set; }
        public string titulo_evento { get; set; }
        public DateTime fecha_evento { get; set; }
        public TimeSpan inicio_hora_evento { get; set; }
        public TimeSpan fin_hora_evento { get; set; }
        public string duracion_evento { get; set; }
        public string descripcion_evento { get; set; }
        public int id_tipo_evento { get; set; }
        public int id_persona { get; set; }
        public int id_local { get; set; }
        public string estado_evento { get; set; }
        public string tipo_persona { get; set; }
    }
}