﻿// <auto-generated />
using System;
using ApplicationCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationCore.Migrations
{
    [DbContext(typeof(ApplicationDbCotext))]
    [Migration("20180822180634_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Models.Area_Reparacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Descripcion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Area_Reparacion");
                });

            modelBuilder.Entity("ApplicationCore.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<string>("Detalle");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("Hora_LLegada");

                    b.Property<int>("Hora_salida");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("ApplicationCore.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Cedula");

                    b.Property<string>("Nombre");

                    b.Property<string>("direccion");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ApplicationCore.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<int>("descripcion");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ApplicationCore.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contraseña");

                    b.Property<string>("Usario");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("ApplicationCore.Models.Empleado_Atiende", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<int?>("EmpleadoId");

                    b.Property<int>("EmpleadosId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Empleado_Atiende");
                });

            modelBuilder.Entity("ApplicationCore.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Area_ReparacionId");

                    b.Property<string>("Costo");

                    b.Property<string>("Garantia");

                    b.HasKey("Id");

                    b.HasIndex("Area_ReparacionId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("ApplicationCore.Models.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacturaId");

                    b.Property<DateTime>("Fecha_entrada");

                    b.Property<DateTime>("Fecha_salida");

                    b.Property<int>("MecanicoId");

                    b.Property<int>("VehiculoId");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.HasIndex("MecanicoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("ApplicationCore.Models.Mecanico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartamentoId");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Mecanicos");
                });

            modelBuilder.Entity("ApplicationCore.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<string>("Matricula");

                    b.Property<string>("Modelo");

                    b.Property<string>("agencia");

                    b.Property<int>("anio");

                    b.Property<string>("estado");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("ApplicationCore.Models.Cita", b =>
                {
                    b.HasOne("ApplicationCore.Models.Cliente", "Cliente")
                        .WithMany("Cita")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Models.Empleado_Atiende", b =>
                {
                    b.HasOne("ApplicationCore.Models.Cliente", "Cliente")
                        .WithMany("Empleado_Atiendes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Models.Empleado", "Empleado")
                        .WithMany("Empleado_Atiendes")
                        .HasForeignKey("EmpleadoId");
                });

            modelBuilder.Entity("ApplicationCore.Models.Factura", b =>
                {
                    b.HasOne("ApplicationCore.Models.Area_Reparacion", "Area_Reparacion")
                        .WithMany("Factura")
                        .HasForeignKey("Area_ReparacionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Models.Mantenimiento", b =>
                {
                    b.HasOne("ApplicationCore.Models.Factura", "Factura")
                        .WithMany("Mantenimientos")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Models.Mecanico", "Mecanico")
                        .WithMany("Mantenimientos")
                        .HasForeignKey("MecanicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Models.Vehiculo", "Vehiculo")
                        .WithMany("Mantenimientos")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Models.Mecanico", b =>
                {
                    b.HasOne("ApplicationCore.Models.Departamento", "Departamento")
                        .WithMany("Mecanicos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Models.Vehiculo", b =>
                {
                    b.HasOne("ApplicationCore.Models.Cliente")
                        .WithMany("Vehiculo")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
