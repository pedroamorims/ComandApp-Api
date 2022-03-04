using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComandApp.Infra.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    SenhaHash = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2022, 3, 4, 18, 36, 8, 141, DateTimeKind.Utc).AddTicks(5157)),
                    DataAlteracao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2022, 3, 4, 18, 36, 8, 141, DateTimeKind.Utc).AddTicks(5402))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2022, 3, 4, 15, 36, 8, 141, DateTimeKind.Local).AddTicks(1643))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPermissao",
                columns: table => new
                {
                    PermissaoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPermissao", x => new { x.PermissaoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioPermissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPermissao_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagemProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "NVARCHAR", nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagemProduto_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tamanho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR(5)", maxLength: 5, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamanho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tamanho_Produto",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComandaProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<int>(type: "int", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    TamanhoId = table.Column<int>(type: "int", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2022, 3, 4, 15, 36, 8, 140, DateTimeKind.Local).AddTicks(9812)),
                    Entregue = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComandaProduto_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComandaProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComandaProduto_Tamanho_TamanhoId",
                        column: x => x.TamanhoId,
                        principalTable: "Tamanho",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Descricao",
                table: "Categoria",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_Codigo",
                table: "Comanda",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComandaProduto_ComandaId",
                table: "ComandaProduto",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaProduto_ProdutoId",
                table: "ComandaProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaProduto_TamanhoId",
                table: "ComandaProduto",
                column: "TamanhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemProduto_ProdutosId",
                table: "ImagemProduto",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_Descricao",
                table: "Permissao",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Nome",
                table: "Produto",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tamanho_ProdutoId",
                table: "Tamanho",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Nome",
                table: "Usuario",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermissao_UsuarioId",
                table: "UsuarioPermissao",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaProduto");

            migrationBuilder.DropTable(
                name: "ImagemProduto");

            migrationBuilder.DropTable(
                name: "UsuarioPermissao");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Tamanho");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
