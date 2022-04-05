using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComandApp.Infra.Migrations
{
    public partial class ColunaAtivoProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 16, 58, 813, DateTimeKind.Utc).AddTicks(2594),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 3, 14, 12, 15, 30, 364, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 13, 16, 58, 813, DateTimeKind.Utc).AddTicks(2952),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 3, 14, 12, 15, 30, 364, DateTimeKind.Utc).AddTicks(8185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 10, 16, 58, 812, DateTimeKind.Local).AddTicks(8746),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 3, 14, 9, 15, 30, 364, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "ComandaProduto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 10, 16, 58, 812, DateTimeKind.Local).AddTicks(6516),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 3, 14, 9, 15, 30, 364, DateTimeKind.Local).AddTicks(2703));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Produto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 14, 12, 15, 30, 364, DateTimeKind.Utc).AddTicks(8000),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 16, 58, 813, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 14, 12, 15, 30, 364, DateTimeKind.Utc).AddTicks(8185),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 13, 16, 58, 813, DateTimeKind.Utc).AddTicks(2952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 14, 9, 15, 30, 364, DateTimeKind.Local).AddTicks(4462),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 10, 16, 58, 812, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "ComandaProduto",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 14, 9, 15, 30, 364, DateTimeKind.Local).AddTicks(2703),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 5, 10, 16, 58, 812, DateTimeKind.Local).AddTicks(6516));
        }
    }
}
