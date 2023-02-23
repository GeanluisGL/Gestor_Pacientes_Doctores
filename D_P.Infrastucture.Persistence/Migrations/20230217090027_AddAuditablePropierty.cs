using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_P.Infrastucture.Persistence.Migrations
{
    public partial class AddAuditablePropierty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifyBy",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Resultados_Laboratorios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Resultados_Laboratorios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Resultados_Laboratorios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifyBy",
                table: "Resultados_Laboratorios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Resultados_Laboratorios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PruebaLaboratorios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PruebaLaboratorios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "PruebaLaboratorios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifyBy",
                table: "PruebaLaboratorios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Pacientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Pacientes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifyBy",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Medicos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Medicos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifyBy",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Citas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Citas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifyBy",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LastModifyBy",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Resultados_Laboratorios");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Resultados_Laboratorios");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Resultados_Laboratorios");

            migrationBuilder.DropColumn(
                name: "LastModifyBy",
                table: "Resultados_Laboratorios");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Resultados_Laboratorios");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "PruebaLaboratorios");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PruebaLaboratorios");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "PruebaLaboratorios");

            migrationBuilder.DropColumn(
                name: "LastModifyBy",
                table: "PruebaLaboratorios");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "LastModifyBy",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "LastModifyBy",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "LastModifyBy",
                table: "Citas");
        }
    }
}
