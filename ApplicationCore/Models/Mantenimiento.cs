using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Mantenimiento : BaseEntity
    {
        public DateTime Fecha_entrada { get; set; }
        public DateTime Fecha_salida { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int MecanicoId { get; set; }
        public Mecanico Mecanico { get; set; }
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
    }
}
