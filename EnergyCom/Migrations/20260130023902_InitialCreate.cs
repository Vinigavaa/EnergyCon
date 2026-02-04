using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyCom.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consumidor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inscricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DebitoConta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumidor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Uc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdConsumidor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uc_Consumidor_IdConsumidor",
                        column: x => x.IdConsumidor,
                        principalTable: "Consumidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CalculoDados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Iduc = table.Column<int>(type: "int", nullable: false),
                    Competencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LeituraAtual = table.Column<double>(type: "double", nullable: false),
                    LeituraAnterior = table.Column<double>(type: "double", nullable: false),
                    ConsumoTotalKwh = table.Column<double>(type: "double", nullable: false),
                    ConsumoPontaKwh = table.Column<double>(type: "double", nullable: false),
                    ConsumoForaKwh = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculoDados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculoDados_Uc_Iduc",
                        column: x => x.Iduc,
                        principalTable: "Uc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    Iduc = table.Column<int>(type: "int", nullable: false),
                    IdCalculo = table.Column<int>(type: "int", nullable: false),
                    Competencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fatura_CalculoDados_IdCalculo",
                        column: x => x.IdCalculo,
                        principalTable: "CalculoDados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fatura_Uc_Iduc",
                        column: x => x.Iduc,
                        principalTable: "Uc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CalculoDados_Iduc",
                table: "CalculoDados",
                column: "Iduc");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_IdCalculo",
                table: "Fatura",
                column: "IdCalculo");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_Iduc",
                table: "Fatura",
                column: "Iduc");

            migrationBuilder.CreateIndex(
                name: "IX_Uc_IdConsumidor",
                table: "Uc",
                column: "IdConsumidor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "CalculoDados");

            migrationBuilder.DropTable(
                name: "Uc");

            migrationBuilder.DropTable(
                name: "Consumidor");
        }
    }
}
