using ComandApp.Domain.Entitities;
using ComandApp.Domain.Respositories;
using System.Collections.Generic;
using System.Linq;

namespace ComandApp.Tests.Repositories
{
    public class FakeComandaRepository : IComandaRepository
    {
        private List<Comanda> _comandas = new List<Comanda>();
        private List<ComandaProduto> _comandaProdutos = new List<ComandaProduto>();
        private int _nextComandaId = 1;
        private int _nextComandaProdutoId = 1;

        public void CriarComanda(Comanda comanda)
        {
            comanda.Id = _nextComandaId++;
            _comandas.Add(comanda);
        }

        public Comanda BuscarComandaPorId(int id)
        {
            return _comandas.FirstOrDefault(c => c.Id == id);
        }

        public void AdicionarProdutoComanda(ComandaProduto comandaProduto)
        {
            // In a real scenario, you might want to ensure the Comanda exists
            // and link the ComandaProduto to it more explicitly if your entities are structured that way.
            comandaProduto.Id = _nextComandaProdutoId++;
            _comandaProdutos.Add(comandaProduto);
            
            var comanda = _comandas.FirstOrDefault(c => c.Id == comandaProduto.IdComanda);
            if (comanda != null && comanda.Produtos.All(p => p.Id != comandaProduto.Id))
            {
                 // This part depends on how Comanda.Produtos is managed.
                 // If Comanda.Produtos is a list of ComandaProduto, you might add it here.
                 // For simplicity, this fake repo assumes ComandaProduto is managed separately
                 // or that the handler/service layer coordinates this.
            }
        }

        public void RemoverProdutoComanda(ComandaProduto comandaProduto)
        {
            var itemToRemove = _comandaProdutos.FirstOrDefault(cp => cp.Id == comandaProduto.Id);
            if (itemToRemove != null)
                _comandaProdutos.Remove(itemToRemove);
        }

        public void AtualizarStatusComanda(Comanda comanda)
        {
            var existingComanda = _comandas.FirstOrDefault(c => c.Id == comanda.Id);
            if (existingComanda != null)
            {
                // Update properties, e.g., existingComanda.Status = comanda.Status;
                // For this fake, we'll assume the object passed in is updated directly by the handler if needed
                // or that a more complex update logic would be here.
            }
        }
    }
}
