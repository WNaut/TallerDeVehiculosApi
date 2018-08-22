using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Mecanico : BaseEntity
    {
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public List<Mantenimiento> Mantenimientos { get; set; }
    }
}
