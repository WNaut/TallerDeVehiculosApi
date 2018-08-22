using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Departamento : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int descripcion { get; set; }
        public List<Mecanico> Mecanicos { get; set; }
    }
}
