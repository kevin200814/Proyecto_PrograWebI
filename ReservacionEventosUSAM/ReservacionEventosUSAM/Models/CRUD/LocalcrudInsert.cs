using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservacionEventosUSAM.Models.CRUD
{
    public class LocalcrudInsert
    {
        public int id_local { get; set; }
        public string nombre_local { get; set; }
    }

    public class LocalcrudUpdate
    {
        public int id_local { get; set; }
        public string nombre_local { get; set; }
    }
}