using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) {}

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Empleado_Atiende> Empleado_Atiende { get; set; }
        public DbSet<Mecanico> Mecanicos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Area_Reparacion> Area_Reparacion { get; set; }

    }
}
