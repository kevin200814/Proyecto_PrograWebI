using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class RegistroInscripcionInsert
    {
        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]

      
        public int id_reservacion { get; set; }
        [Display(Name = "nombre")]
        public string nombres_persona { get; set; }

        [Required]
        [Display(Name = "apellido")]
        public string apellidos_persona { get; set; }

        [Required]
        [Display(Name = "telefono")]
        public string telefono_persona { get; set; }

        [Required]
        [Display(Name = "correo")]
        public string correo_persona { get; set; } 
        public int id_tipo_persona { get; set; }
       
    }
}