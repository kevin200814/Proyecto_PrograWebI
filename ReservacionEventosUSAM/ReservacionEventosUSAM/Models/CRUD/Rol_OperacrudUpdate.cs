using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace ReservacionEventosUSAM.Models.CRUD
{
    public class Rol_OperacrudUpdate
    {
        [Required]
        [Display(Name = "id_rol_opera")]
        public int id_rol_opera { get; set; }
        [Required]
        [Display(Name = "id_rol")]
        public int id_rol { get; set; }
        [Required]
        [Display(Name = "codopera")]
        public int codopera { get; set; }
    }
}