using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class PersonaEventosUpdate
    {
        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "nombre")]

        public string nombres_persona { get; set; }
        [Required]
        [Display(Name = "apellido")]

        public string apellidos_persona { get; set; }
        [Required]
        [Display(Name = "profesion")]

        public string profesion_persona { get; set; }
        public int id_persona { get; set; }
    }
}