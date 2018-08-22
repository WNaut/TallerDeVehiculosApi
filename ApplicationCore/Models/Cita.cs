using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Cita : BaseEntity
    {
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora_salida { get; set; }
        public int Hora_LLegada { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
