using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyCom.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntityColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Uc",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteAt",
                table: "Uc",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Uc",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Fatura",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteAt",
                table: "Fatura",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Fatura",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Consumidor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteAt",
                table: "Consumidor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Consumidor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<double>(
                name: "AliquotaCofins",
                table: "CalculoDados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AliquotaIcms",
                table: "CalculoDados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AliquotaPis",
                table: "CalculoDados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CalculoDados",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteAt",
                table: "CalculoDados",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<double>(
                name: "TarifaKwh",
                table: "CalculoDados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "CalculoDados",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<double>(
                name: "ValorCofins",
                table: "CalculoDados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorIcms",
                table: "CalculoDados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorPis",
                table: "CalculoDados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorSemImpostos",
                table: "CalculoDados",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Uc");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Uc");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Uc");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Consumidor");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Consumidor");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Consumidor");

            migrationBuilder.DropColumn(
                name: "AliquotaCofins",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "AliquotaIcms",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "AliquotaPis",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "TarifaKwh",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "ValorCofins",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "ValorIcms",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "ValorPis",
                table: "CalculoDados");

            migrationBuilder.DropColumn(
                name: "ValorSemImpostos",
                table: "CalculoDados");
        }
    }
}
