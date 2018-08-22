using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Factura : BaseEntity
    {
        public string Garantia { get; set; }
        public string Costo { get; set; }
        public List<Mantenimiento> Mantenimientos { get; set; }
        public int Area_ReparacionId { get; set; }
        public Area_Reparacion Area_Reparacion { get; set; }

    }
}
