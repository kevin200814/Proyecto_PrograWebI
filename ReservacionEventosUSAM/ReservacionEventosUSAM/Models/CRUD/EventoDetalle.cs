using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class EventoDetalle
    {
        /*Tabla Reservacion Evento*/
        public int id_reservacion { get; set; }
        public string titulo_evento { get; set; }
        public DateTime fecha_evento { get; set; }
        public TimeSpan inicio_hora_evento { get; set; }
        public TimeSpan fin_hora_evento { get; set; }
        public string duracion_evento { get; set; }
        public string descripcion_evento { get; set; }
        public int? id_tipo_evento { get; set; }
        public int? id_persona { get; set; }
        public int? id_local { get; set; }
        public string estado_evento { get; set; }
        public string tipo_persona { get; set; }

        /*Tabla Persona Evento*/
        public string nombres_persona { get; set; }
        public string apellidos_persona { get; set; }
        public string profesion_persona { get; set; }

        /*Tabla Local Evento*/

        public string nombre_local { get; set; }

        /*Tabla Tipo persona*/
        public string tipo_personaa { get; set; }
        public decimal costo_pago_persona { get; set; }
    }
}