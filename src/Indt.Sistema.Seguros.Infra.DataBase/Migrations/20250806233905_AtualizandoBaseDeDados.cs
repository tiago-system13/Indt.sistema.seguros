using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indt.Sistema.Seguros.Infra.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoBaseDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DataInicial",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato",
                type: "DateTimeOffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DataFinal",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato",
                type: "DateTimeOffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "DateTimeOffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "DateTimeOffset");
        }
    }
}
