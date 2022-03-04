using ComandApp.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ComandAppModels.Dados.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Tabela
            builder.ToTable("Usuario");

            //Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
               // .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Email)
                 .IsRequired()
                 .HasColumnType("VARCHAR")
                 .HasMaxLength(160);

            builder.Property(x => x.SenhaHash)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.UtcNow);


            builder.Property(x => x.DataAlteracao)
              .IsRequired()
              .HasColumnType("SMALLDATETIME")
              .HasDefaultValue(DateTime.UtcNow);

            // Indices
            builder.HasIndex(x => x.Nome, "IX_Usuario_Nome").IsUnique();

            //Relacionamento

            builder.HasMany(x => x.Permissoes)
                .WithMany(x => x.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                "UsuarioPermissao",
                usuario => usuario.HasOne<Permissao>()
                .WithMany()
                .HasForeignKey("UsuarioId")
                .HasConstraintName("FK_UsuarioPermissao_UsuarioId"),
                 permissao => permissao.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey("PermissaoId")
                .HasConstraintName("FK_UsuarioPermissao_PermissaoId")


                );

        }
    }
}
