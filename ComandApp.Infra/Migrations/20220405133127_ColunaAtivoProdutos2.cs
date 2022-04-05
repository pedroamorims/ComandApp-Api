using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComandApp.Infra.Migrations
{
    public partial class ColunaAtivoProdutos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 31, 27, 632, DateTimeKind.Utc).AddTicks(8430),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 16, 58, 813, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 31, 27, 632, DateTimeKind.Utc).AddTicks(8670),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 16, 58, 813, DateTimeKind.Utc).AddTicks(2952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 10, 31, 27, 632, DateTimeKind.Local).AddTicks(4517),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 10, 16, 58, 812, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "ComandaProduto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 10, 31, 27, 632, DateTimeKind.Local).AddTicks(2522),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 10, 16, 58, 812, DateTimeKind.Local).AddTicks(6516));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 16, 58, 813, DateTimeKind.Utc).AddTicks(2594),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 31, 27, 632, DateTimeKind.Utc).AddTicks(8430));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 16, 58, 813, DateTimeKind.Utc).AddTicks(2952),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 31, 27, 632, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 10, 16, 58, 812, DateTimeKind.Local).AddTicks(8746),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 10, 31, 27, 632, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "ComandaProduto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 10, 16, 58, 812, DateTimeKind.Local).AddTicks(6516),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 10, 31, 27, 632, DateTimeKind.Local).AddTicks(2522));
        }
    }
}
