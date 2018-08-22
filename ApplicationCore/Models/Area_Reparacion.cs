using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Area_Reparacion : BaseEntity
    {
        public string Nombre { get; set; }
        public int Descripcion { get; set; }
        public List<Factura> Factura { get; set; }
    }
}
