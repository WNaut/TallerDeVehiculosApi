using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerDeVehiculosApi.DTO.Cita;
using TallerDeVehiculosApi.DTO.Cliente;
using TallerDeVehiculosApi.DTO.Empleado;

namespace TallerDeVehiculosApi.Helpers
{
    /// <summary>
    /// Configuring AutoMapper
    /// </summary>
    public static class AutoMapperHelper
    {
        public static void AddAutomapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //Empleado
                cfg.CreateMap<EmpleadoCreateDTO, Empleado>();

                //Cliente
                cfg.CreateMap<ClienteCreateDTO, Cliente>();

                //Cita
                cfg.CreateMap<CitaCreateDTO, Cita>();
            }); 
        }
    }
}
