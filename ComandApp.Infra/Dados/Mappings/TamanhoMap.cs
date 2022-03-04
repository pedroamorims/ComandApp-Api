using ComandApp.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandAppModels.Dados.Mappings
{
    public class TamanhoMap : IEntityTypeConfiguration<Tamanho>
    {
        public void Configure(EntityTypeBuilder<Tamanho> builder)
        {
            //Tabela
            builder.ToTable("Tamanho");

            //Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
               // .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            //Propriedades
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(5);

        }
    }
}
