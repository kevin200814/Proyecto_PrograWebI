using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class TipoPersonaInsert
    {
        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "persona")]
        public string tipo_persona { get; set; }
        [Required]
        [Display(Name = "costo")]
        public decimal costo_pago_evento { get; set; }
        public int id_tipo_persona { get; set; }
    }
}