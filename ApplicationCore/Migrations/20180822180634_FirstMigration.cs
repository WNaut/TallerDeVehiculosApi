using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area_Reparacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area_Reparacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    descripcion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Usario = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Garantia = table.Column<string>(nullable: true),
                    Costo = table.Column<string>(nullable: true),
                    Area_ReparacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Area_Reparacion_Area_ReparacionId",
                        column: x => x.Area_ReparacionId,
                        principalTable: "Area_Reparacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Hora_salida = table.Column<int>(nullable: false),
                    Hora_LLegada = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(nullable: true),
                    Matricula = table.Column<string>(nullable: true),
                    anio = table.Column<int>(nullable: false),
                    estado = table.Column<string>(nullable: true),
                    agencia = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mecanicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mecanicos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado_Atiende",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    EmpleadosId = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado_Atiende", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Atiende_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_Atiende_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha_entrada = table.Column<DateTime>(nullable: false),
                    Fecha_salida = table.Column<DateTime>(nullable: false),
                    VehiculoId = table.Column<int>(nullable: false),
                    MecanicoId = table.Column<int>(nullable: false),
                    FacturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Mecanicos_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Mecanicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ClienteId",
                table: "Citas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Atiende_ClienteId",
                table: "Empleado_Atiende",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Atiende_EmpleadoId",
                table: "Empleado_Atiende",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Area_ReparacionId",
                table: "Facturas",
                column: "Area_ReparacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_FacturaId",
                table: "Mantenimientos",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_MecanicoId",
                table: "Mantenimientos",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_VehiculoId",
                table: "Mantenimientos",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mecanicos_DepartamentoId",
                table: "Mecanicos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ClienteId",
                table: "Vehiculos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Empleado_Atiende");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Mecanicos");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Area_Reparacion");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
