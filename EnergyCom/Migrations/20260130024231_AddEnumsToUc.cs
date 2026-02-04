using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyCom.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumsToUc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Classe",
                table: "Uc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Grupo",
                table: "Uc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubClasse",
                table: "Uc",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classe",
                table: "Uc");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "Uc");

            migrationBuilder.DropColumn(
                name: "SubClasse",
                table: "Uc");
        }
    }
}
