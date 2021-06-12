using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace ReservacionEventosUSAM.Models.CRUD
{
    public class RolesInsert
    {
        public int id_rol { get; set; }
        [Required]
        public string rol { get; set; }
    }
}