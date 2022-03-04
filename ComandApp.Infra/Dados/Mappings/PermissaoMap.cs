using ComandApp.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandAppModels.Dados.Mappings
{
    public class PermissaoMap : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            //Tabela
            builder.ToTable("Permissao");

            //Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
               // .UseIdentityColumn();

            //Propriedades
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);


            // Indices
            builder.HasIndex(x => x.Descricao, "IX_Permissao_Descricao").IsUnique();


        }
    }
}
