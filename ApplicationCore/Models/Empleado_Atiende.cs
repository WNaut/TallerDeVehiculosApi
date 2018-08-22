using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Empleado_Atiende : BaseEntity
    {
        public int ClienteId { get; set; }
        public int EmpleadosId { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
    }
}
