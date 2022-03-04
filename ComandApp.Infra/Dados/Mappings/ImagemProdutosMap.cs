using ComandApp.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandAppModels.Dados.Mappings
{
    public class ImagemProdutoMap : IEntityTypeConfiguration<ImagemProduto>
    {
        public void Configure(EntityTypeBuilder<ImagemProduto> builder)
        {
            //Tabela
            builder.ToTable("ImagemProduto");

            //Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
               // .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Url)
                .IsRequired()
                .HasColumnType("NVARCHAR");



            //Relacionamento
            builder.HasOne(x => x.Produtos);

        }
    }
}
