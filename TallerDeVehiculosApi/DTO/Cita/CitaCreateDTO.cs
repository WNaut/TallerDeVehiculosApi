using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDeVehiculosApi.DTO.Cita
{
    /// <summary>
    /// Cita data transfer object 
    /// </summary>
    public class CitaCreateDTO
    {
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora_salida { get; set; }
        public int Hora_LLegada { get; set; }
        public int ClienteId { get; set; }
    }
}
