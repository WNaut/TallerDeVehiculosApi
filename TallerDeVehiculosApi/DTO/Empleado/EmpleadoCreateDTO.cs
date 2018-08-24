using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDeVehiculosApi.DTO.Empleado
{
    /// <summary>
    /// Empleado data transfer object 
    /// </summary>
    public class EmpleadoCreateDTO
    {
        public string Usario { get; set; }
        public string Contraseña { get; set; }
    }
}
