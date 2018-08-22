using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Vehiculo : BaseEntity
    {
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public int anio { get; set; }
        public string estado { get; set; }
        public string agencia { get; set; }
        public int ClienteId { get; set; }
        public List<Mantenimiento> Mantenimientos { get; set; }
    }
}
