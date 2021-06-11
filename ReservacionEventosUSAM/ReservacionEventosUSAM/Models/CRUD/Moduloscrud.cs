using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace ReservacionEventosUSAM.Models.CRUD
{
    public class Moduloscrud
    {
        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre modulo")]
        public string nombre { get; set; }
        public int codmod { get; set; }
    }
}