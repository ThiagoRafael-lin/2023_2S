using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Health_Clinic_Tarde.Migrations
{
    /// <inheritdoc />
    public partial class HorarioAlteradoParaTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Usuario_IdUsuario",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_TipoUsuario_IdTipoUsuario",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Clinica_IdClinica",
                table: "Medico");

            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Especialidade_IdEspecialidade",
                table: "Medico");

            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Usuario_IdUsuario",
                table: "Medico");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Usuario_IdUsuario",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoUsuario_IdTipoUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataFuncionamento",
                table: "Clinica");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HorarioFuncionamento",
                table: "Clinica",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Usuario_IdUsuario",
                table: "Comentario",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_TipoUsuario_IdTipoUsuario",
                table: "Consulta",
                column: "IdTipoUsuario",
                principalTable: "TipoUsuario",
                principalColumn: "IdTipoUsuario",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Clinica_IdClinica",
                table: "Medico",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "IdClinica",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Especialidade_IdEspecialidade",
                table: "Medico",
                column: "IdEspecialidade",
                principalTable: "Especialidade",
                principalColumn: "IdEspecialidade",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Usuario_IdUsuario",
                table: "Medico",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Usuario_IdUsuario",
                table: "Paciente",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoUsuario_IdTipoUsuario",
                table: "Usuario",
                column: "IdTipoUsuario",
                principalTable: "TipoUsuario",
                principalColumn: "IdTipoUsuario",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Usuario_IdUsuario",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_TipoUsuario_IdTipoUsuario",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Clinica_IdClinica",
                table: "Medico");

            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Especialidade_IdEspecialidade",
                table: "Medico");

            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Usuario_IdUsuario",
                table: "Medico");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Usuario_IdUsuario",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoUsuario_IdTipoUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "HorarioFuncionamento",
                table: "Clinica");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFuncionamento",
                table: "Clinica",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Usuario_IdUsuario",
                table: "Comentario",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_TipoUsuario_IdTipoUsuario",
                table: "Consulta",
                column: "IdTipoUsuario",
                principalTable: "TipoUsuario",
                principalColumn: "IdTipoUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Clinica_IdClinica",
                table: "Medico",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Especialidade_IdEspecialidade",
                table: "Medico",
                column: "IdEspecialidade",
                principalTable: "Especialidade",
                principalColumn: "IdEspecialidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Usuario_IdUsuario",
                table: "Medico",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Usuario_IdUsuario",
                table: "Paciente",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoUsuario_IdTipoUsuario",
                table: "Usuario",
                column: "IdTipoUsuario",
                principalTable: "TipoUsuario",
                principalColumn: "IdTipoUsuario");
        }
    }
}
