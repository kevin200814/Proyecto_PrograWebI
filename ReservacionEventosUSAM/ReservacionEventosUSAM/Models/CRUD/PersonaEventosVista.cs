using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class PersonaEventosVista
    {
        public int id_persona { get; set; }
        public string nombres_persona { get; set; }
        public string apellidos_persona { get; set; }
        public string profesion_persona { get; set; }
    }
}