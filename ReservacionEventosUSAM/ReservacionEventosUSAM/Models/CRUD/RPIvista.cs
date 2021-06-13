using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class RPIvista
    {
        /*[registro_inscripcion]*/
        public int id_inscripcion { get; set; }
        public int id_reservacion { get; set; }
        public string nombres_persona { get; set; }
        public string apellidos_persona { get; set; }
        public string telefono_persona { get; set; }
        public string correo_persona { get; set; }
        public int id_tipo_persona { get; set; }


        /*[reservacion_evento]*/
        /*public int id_reservacion { get; set; }*/
        public string titulo_evento { get; set; }
        public DateTime fecha_evento { get; set; }
        public TimeSpan inicio_hora_evento { get; set; }
        public TimeSpan fin_hora_evento { get; set; }
        public string duracion_evento { get; set; }
        public string descripcion_evento { get; set; }
        public int? id_tipo_evento { get; set; }
        public int? id_persona { get; set; }
        public int? id_local { get; set; }
        public string estado_persona { get; set; }
        /*public string tipo_persona { get; set; }*/

        

        /*[tipo_persona]*/
        /*public int id_tipo_persona { get; set; }*/
        public string tipo_persona { get; set; }
        public double costo_pago_evento { get; set; }

    }
}