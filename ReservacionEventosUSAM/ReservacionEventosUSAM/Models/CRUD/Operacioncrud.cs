using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace ReservacionEventosUSAM.Models.CRUD
{
    public class Operacioncrud
    {
        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre operación")]
        public string nomopera { get; set; }
        [Required]
        [Display(Name = "Modulo")]
        public int codmod { get; set; }
        public int codopera { get; set; }
    }
}