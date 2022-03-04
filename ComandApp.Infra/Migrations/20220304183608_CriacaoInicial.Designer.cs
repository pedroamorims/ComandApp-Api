﻿// <auto-generated />
using System;
using ComandApp.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComandApp.Infra.Migrations
{
    [DbContext(typeof(ComandAppDataContext))]
    [Migration("20220304183608_CriacaoInicial")]
    partial class CriacaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ComandApp.Domain.Entitities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)");

                    b.Property<string>("IconURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Descricao" }, "IX_Categoria_Descricao")
                        .IsUnique();

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Codigo" }, "IX_Comanda_Codigo")
                        .IsUnique();

                    b.ToTable("Comanda", (string)null);
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.ComandaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ComandaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2022, 3, 4, 15, 36, 8, 140, DateTimeKind.Local).AddTicks(9812));

                    b.Property<bool>("Entregue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal?>("Preco")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("TamanhoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("TamanhoId");

                    b.ToTable("ComandaProduto", (string)null);
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.ImagemProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProdutosId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("ProdutosId");

                    b.ToTable("ImagemProduto", (string)null);
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Permissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Descricao" }, "IX_Permissao_Descricao")
                        .IsUnique();

                    b.ToTable("Permissao", (string)null);
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2022, 3, 4, 15, 36, 8, 141, DateTimeKind.Local).AddTicks(1643));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("SMALLDATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex(new[] { "Nome" }, "IX_Produto_Nome")
                        .IsUnique();

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Tamanho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR(5)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Preco")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Tamanho", (string)null);
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2022, 3, 4, 18, 36, 8, 141, DateTimeKind.Utc).AddTicks(5402));

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2022, 3, 4, 18, 36, 8, 141, DateTimeKind.Utc).AddTicks(5157));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("VARCHAR(160)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Nome" }, "IX_Usuario_Nome")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("UsuarioPermissao", b =>
                {
                    b.Property<int>("PermissaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PermissaoId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioPermissao");
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.ComandaProduto", b =>
                {
                    b.HasOne("ComandApp.Domain.Entitities.Comanda", "Comanda")
                        .WithMany()
                        .HasForeignKey("ComandaId");

                    b.HasOne("ComandApp.Domain.Entitities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("ComandApp.Domain.Entitities.Tamanho", "Tamanho")
                        .WithMany()
                        .HasForeignKey("TamanhoId");

                    b.Navigation("Comanda");

                    b.Navigation("Produto");

                    b.Navigation("Tamanho");
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.ImagemProduto", b =>
                {
                    b.HasOne("ComandApp.Domain.Entitities.Produto", "Produtos")
                        .WithMany()
                        .HasForeignKey("ProdutosId");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Produto", b =>
                {
                    b.HasOne("ComandApp.Domain.Entitities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("FK_Produto_Categoria");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Tamanho", b =>
                {
                    b.HasOne("ComandApp.Domain.Entitities.Produto", "Produto")
                        .WithMany("Tamanhos")
                        .HasForeignKey("ProdutoId")
                        .HasConstraintName("FK_Tamanho_Produto");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("UsuarioPermissao", b =>
                {
                    b.HasOne("ComandApp.Domain.Entitities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UsuarioPermissao_PermissaoId");

                    b.HasOne("ComandApp.Domain.Entitities.Permissao", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UsuarioPermissao_UsuarioId");
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ComandApp.Domain.Entitities.Produto", b =>
                {
                    b.Navigation("Tamanhos");
                });
#pragma warning restore 612, 618
        }
    }
}
