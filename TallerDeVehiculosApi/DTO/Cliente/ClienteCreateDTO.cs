using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDeVehiculosApi.DTO.Cliente
{
    /// <summary>
    /// Cliente data transfer object 
    /// </summary>
    public class ClienteCreateDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string direccion { get; set; }
        public string Cedula { get; set; }
    }
}
