using ComandApp.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandAppModels.Dados.Mappings
{
    public class ComandaProdutoMap : IEntityTypeConfiguration<ComandaProduto>
    {
        public void Configure(EntityTypeBuilder<ComandaProduto> builder)
        {
            //Tabela
            builder.ToTable("ComandaProduto");

            //Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
      //          .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
  

            builder.Property(x => x.Entregue)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.DataPedido)
                .IsRequired()
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now);


            //Relacionamento
            builder.HasOne(x => x.Tamanho);

            builder.HasOne(x => x.Comanda);

            builder.HasOne(x => x.Produto);


        }
    }
}
