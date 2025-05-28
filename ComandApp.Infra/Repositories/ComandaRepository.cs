using ComandApp.Domain.Entitities;
using ComandApp.Domain.Respositories;
using ComandApp.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ComandApp.Infra.Repositories
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly ComandAppDataContext _context;

        public ComandaRepository(ComandAppDataContext context)
        {
            _context = context;
        }

        public void CriarComanda(Comanda comanda)
        {
            _context.Comandas.Add(comanda);
            _context.SaveChanges();
        }

        public Comanda BuscarComandaPorId(int id)
        {
            return _context.Comandas
                .Include(c => c.Produtos)
                .ThenInclude(cp => cp.Produto)
                .FirstOrDefault(c => c.Id == id);
        }

        public void AdicionarProdutoComanda(ComandaProduto comandaProduto)
        {
            _context.ComandaProdutos.Add(comandaProduto);
            _context.SaveChanges();
        }

        public void RemoverProdutoComanda(ComandaProduto comandaProduto)
        {
            _context.ComandaProdutos.Remove(comandaProduto);
            _context.SaveChanges();
        }

        public void AtualizarStatusComanda(Comanda comanda)
        {
            _context.Entry(comanda).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Implement other necessary methods
    }
}
