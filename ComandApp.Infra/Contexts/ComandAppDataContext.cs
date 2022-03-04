using ComandApp.Domain.Entitities;
using ComandAppModels.Dados.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ComandApp.Infra.Contexts
{
    public class ComandAppDataContext : DbContext
    {

        public ComandAppDataContext(DbContextOptions<ComandAppDataContext> options) : base(options)
        {

        }
        public DbSet<Categoria>? Categorias { get; set; }

        public DbSet<Comanda>? Comandas { get; set; }

        public DbSet<ComandaProduto>? ComandasPedidos { get; set; }

        public DbSet<ImagemProduto>? ImagensProdutos { get; set; }

        public DbSet<Produto>? Produtos { get; set; }

        public DbSet<Tamanho>? TamanhosProdutos { get; set; }

        public DbSet<Usuario>? Usuarios { get; set; }

        public DbSet<Permissao>? Permissoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ComandaMap());
            modelBuilder.ApplyConfiguration(new ComandaProdutoMap());
            modelBuilder.ApplyConfiguration(new ImagemProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new TamanhoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());

        }


    }
}
