using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indt.Sistema.Seguros.Infra.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaSistemaSeguro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "idtsistemaseguro");

            migrationBuilder.CreateTable(
                name: "Tb_Contrato",
                schema: "idtsistemaseguro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    PropostaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prazo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Contrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Parcela",
                schema: "idtsistemaseguro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Parcela_Tb_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalSchema: "idtsistemaseguro",
                        principalTable: "Tb_Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Proposta",
                schema: "idtsistemaseguro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    TipoSeguro = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTimeOffset>(type: "DateTimeOffset", nullable: false),
                    DataFim = table.Column<DateTimeOffset>(type: "DateTimeOffset", nullable: false),
                    StatusProposta = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prazo = table.Column<int>(type: "int", nullable: false),
                    DocumentoCliente = table.Column<string>(type: "varchar(20)", nullable: false),
                    NomeCliente = table.Column<string>(type: "varchar(80)", nullable: false),
                    DataNascimentoCliente = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NumeroEnderecoCliente = table.Column<int>(type: "int", nullable: false),
                    LogradouroEnderecoCliente = table.Column<string>(type: "varchar(80)", nullable: false),
                    CepEnderecoCliente = table.Column<string>(type: "varchar(9)", nullable: false),
                    BairroEnderecoCliente = table.Column<string>(type: "varchar(60)", nullable: false),
                    CidadeEnderecoCliente = table.Column<string>(type: "varchar(60)", nullable: false),
                    EstadoEnderecoCliente = table.Column<string>(type: "varchar(2)", nullable: false),
                    NumeroContatoCliente = table.Column<string>(type: "varchar(10)", nullable: false),
                    DddContatoCliente = table.Column<string>(type: "varchar(3)", nullable: false),
                    EmailContatoCliente = table.Column<string>(type: "varchar(60)", nullable: false),
                    MarcaBem = table.Column<string>(type: "varchar(30)", nullable: false),
                    AnoFabricacaoBem = table.Column<string>(type: "varchar(4)", nullable: false),
                    PlacaBem = table.Column<string>(type: "varchar(10)", nullable: false),
                    CategoriaBem = table.Column<int>(type: "int", nullable: false),
                    UtilizacaoBem = table.Column<string>(type: "varchar(255)", nullable: false),
                    CorBem = table.Column<string>(type: "varchar(20)", nullable: false),
                    ChassiBem = table.Column<string>(type: "varchar(30)", nullable: false),
                    DescricaoCobertura = table.Column<string>(type: "varchar(255)", nullable: false),
                    LimiteIdenizacaoCobertura = table.Column<string>(type: "varchar(80)", nullable: false),
                    PremioCobertura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FranquiaCobertura = table.Column<bool>(type: "bit", nullable: false),
                    ValorFranquiaCobertura = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Proposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Proposta_Tb_Contrato_Id",
                        column: x => x.Id,
                        principalSchema: "idtsistemaseguro",
                        principalTable: "Tb_Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Parcela_ContratoId",
                schema: "idtsistemaseguro",
                table: "Tb_Parcela",
                column: "ContratoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Parcela",
                schema: "idtsistemaseguro");

            migrationBuilder.DropTable(
                name: "Tb_Proposta",
                schema: "idtsistemaseguro");

            migrationBuilder.DropTable(
                name: "Tb_Contrato",
                schema: "idtsistemaseguro");
        }
    }
}
