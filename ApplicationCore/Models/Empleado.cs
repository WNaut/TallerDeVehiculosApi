using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Empleado : BaseEntity
    {
        public int Id { get; set; }
        public string Usario { get; set; }
        public string Contraseña { get; set; }
        public List<Empleado_Atiende> Empleado_Atiendes { get; set; }

    }
}
