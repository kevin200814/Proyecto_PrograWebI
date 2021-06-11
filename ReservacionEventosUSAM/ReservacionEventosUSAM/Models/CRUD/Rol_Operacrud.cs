using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace ReservacionEventosUSAM.Models.CRUD
{
    public class Rol_Operacrud
    {
        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "id_rol")]
        public int id_rol { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "codopera")]
        public int codopera { get; set; }
        public int id_rol_opera { get; set; }
    }
}