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
    
    public partial class tipo_persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_persona()
        {
            this.registro_inscripcion = new HashSet<registro_inscripcion>();
        }
    
        public int id_tipo_persona { get; set; }
        public int tipo_persona1 { get; set; }
        public decimal costo_pago_evento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro_inscripcion> registro_inscripcion { get; set; }
    }
}
