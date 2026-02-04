using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyCom.Migrations
{
    /// <inheritdoc />
    public partial class AddMotivoBaixaToFatura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotivoBaixa",
                table: "Fatura",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotivoBaixa",
                table: "Fatura");
        }
    }
}
