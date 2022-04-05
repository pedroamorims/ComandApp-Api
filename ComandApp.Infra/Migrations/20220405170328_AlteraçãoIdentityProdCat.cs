using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComandApp.Infra.Migrations
{
    public partial class AlteraçãoIdentityProdCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 17, 3, 28, 426, DateTimeKind.Utc).AddTicks(9280),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 16, 38, 28, 667, DateTimeKind.Utc).AddTicks(1706));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 17, 3, 28, 426, DateTimeKind.Utc).AddTicks(9493),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 16, 38, 28, 667, DateTimeKind.Utc).AddTicks(1943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 14, 3, 28, 426, DateTimeKind.Local).AddTicks(5072),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 14, 3, 28, 426, DateTimeKind.Local).AddTicks(5366),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "ComandaProduto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 14, 3, 28, 426, DateTimeKind.Local).AddTicks(2818),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(5192));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 16, 38, 28, 667, DateTimeKind.Utc).AddTicks(1706),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 17, 3, 28, 426, DateTimeKind.Utc).AddTicks(9280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 16, 38, 28, 667, DateTimeKind.Utc).AddTicks(1943),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 17, 3, 28, 426, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(7420),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 14, 3, 28, 426, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(7648),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 14, 3, 28, 426, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "ComandaProduto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 38, 28, 666, DateTimeKind.Local).AddTicks(5192),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 14, 3, 28, 426, DateTimeKind.Local).AddTicks(2818));
        }
    }
}
