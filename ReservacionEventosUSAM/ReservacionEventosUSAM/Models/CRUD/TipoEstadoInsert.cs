using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class TipoEstadoInsert
    {

        public int cod_estado { get; set; }

        [Required]
        public string estado { get; set; }
    }
}