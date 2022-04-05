using ComandApp.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandAppModels.Dados.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //Tabela
            builder.ToTable("Produto");

            //Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.Ativo)
            .IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now);


            builder.Property(x => x.DataAlteracao)
              .IsRequired()
              .HasColumnType("SMALLDATETIME")
              .HasDefaultValue(DateTime.Now);

            // Indices
            builder.HasIndex(x => x.Nome, "IX_Produto_Nome").IsUnique();

            //Relacionamento

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Produtos)
                .HasConstraintName("FK_Produto_Categoria");

            builder.HasMany(x => x.Tamanhos)
            .WithOne(x => x.Produto)
            .HasConstraintName("FK_Tamanho_Produto");


        }
    }
}
