using ComandApp.Domain.Entitities;

namespace ComandApp.Domain.Respositories
{
    public interface IComandaRepository
    {
        void CriarComanda(Comanda comanda);
        Comanda BuscarComandaPorId(int id);
        void AdicionarProdutoComanda(ComandaProduto comandaProduto);
        void RemoverProdutoComanda(ComandaProduto comandaProduto);
        void AtualizarStatusComanda(Comanda comanda);
        // Add other necessary methods
    }
}
