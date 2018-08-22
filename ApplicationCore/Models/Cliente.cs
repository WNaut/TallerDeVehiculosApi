using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Cliente : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string direccion { get; set; }
        public string Cedula { get; set; }
        public List<Cita> Cita { get; set; }
        public List<Vehiculo> Vehiculo { get; set; }
        public List<Empleado_Atiende> Empleado_Atiendes { get; set; }
    }
}
