using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComandApp.Infra.Migrations
{
    public partial class DataCriacaoAutomatica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 16, 38, 28, 667, DateTimeKind.Utc).AddTicks(1706),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 31, 27, 632, DateTimeKind.Utc).AddTicks(8430));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 16, 38, 28, 667, DateTimeKind.Utc).AddTicks(1943),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 31, 27, 632, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(7420),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(7648),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 10, 31, 27, 632, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "ComandaProduto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(5192),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 10, 31, 27, 632, DateTimeKind.Local).AddTicks(2522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 31, 27, 632, DateTimeKind.Utc).AddTicks(8430),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 16, 38, 28, 667, DateTimeKind.Utc).AddTicks(1706));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 31, 27, 632, DateTimeKind.Utc).AddTicks(8670),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 16, 38, 28, 667, DateTimeKind.Utc).AddTicks(1943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 10, 31, 27, 632, DateTimeKind.Local).AddTicks(4517),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "ComandaProduto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 10, 31, 27, 632, DateTimeKind.Local).AddTicks(2522),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(5192));
        }
    }
}
