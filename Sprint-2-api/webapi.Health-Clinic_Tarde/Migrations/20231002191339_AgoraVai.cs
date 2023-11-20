using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Health_Clinic_Tarde.Migrations
{
    /// <inheritdoc />
    public partial class AgoraVai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioFuncionamento",
                table: "Clinica",
                newName: "HorarioFechamento");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioAbertura",
                table: "Clinica");

            migrationBuilder.RenameColumn(
                name: "HorarioFechamento",
                table: "Clinica",
                newName: "HorarioFuncionamento");
        }
    }
}
