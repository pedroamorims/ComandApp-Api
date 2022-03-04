using ComandApp.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandAppModels.Dados.Mappings
{
    internal class ComandaMap : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            //Tabela
            builder.ToTable("Comanda");

            //Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
                //.UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);


            // Indices
            builder.HasIndex(x => x.Codigo, "IX_Comanda_Codigo").IsUnique();


        }
    }
}
