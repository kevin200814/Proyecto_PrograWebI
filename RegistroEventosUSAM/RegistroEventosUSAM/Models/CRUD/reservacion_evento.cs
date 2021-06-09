//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistroEventosUSAM.Models.CRUD
{
    using System;
    using System.Collections.Generic;
    
    public partial class reservacion_evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reservacion_evento()
        {
            this.registro_inscripcion = new HashSet<registro_inscripcion>();
        }
    
        public int id_reservacion { get; set; }
        public string titulo_evento { get; set; }
        public System.DateTime fecha_evento { get; set; }
        public System.TimeSpan inicio_hora_evento { get; set; }
        public System.TimeSpan fin_hora_evento { get; set; }
        public string duracion_evento { get; set; }
        public string descripcion_evento { get; set; }
        public int id_tipo_evento { get; set; }
        public int id_persona { get; set; }
        public int id_local { get; set; }
        public string estado_evento { get; set; }
        public string tipo_persona { get; set; }
    
        public virtual local_evento local_evento { get; set; }
        public virtual persona_eventos persona_eventos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro_inscripcion> registro_inscripcion { get; set; }
        public virtual tipo_evento tipo_evento { get; set; }
    }
}
