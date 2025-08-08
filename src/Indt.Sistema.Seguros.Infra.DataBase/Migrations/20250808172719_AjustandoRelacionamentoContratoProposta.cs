using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indt.Sistema.Seguros.Infra.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoRelacionamentoContratoProposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Contrato_Tb_Proposta_Id",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Contrato_PropostaId",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato",
                column: "PropostaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Contrato_Tb_Proposta_PropostaId",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato",
                column: "PropostaId",
                principalSchema: "idtsistemaseguro",
                principalTable: "Tb_Proposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Contrato_Tb_Proposta_PropostaId",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Contrato_PropostaId",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Contrato_Tb_Proposta_Id",
                schema: "idtsistemaseguro",
                table: "Tb_Contrato",
                column: "Id",
                principalSchema: "idtsistemaseguro",
                principalTable: "Tb_Proposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
