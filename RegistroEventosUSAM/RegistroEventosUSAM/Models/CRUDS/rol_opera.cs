//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistroEventosUSAM.Models.CRUDS
{
    using System;
    using System.Collections.Generic;
    
    public partial class rol_opera
    {
        public int id_rol_opera { get; set; }
        public int id_rol { get; set; }
        public int codopera { get; set; }
    
        public virtual operaciones operaciones { get; set; }
        public virtual roles roles { get; set; }
    }
}
