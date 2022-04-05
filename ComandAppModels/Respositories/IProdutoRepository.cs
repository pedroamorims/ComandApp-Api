using ComandApp.Domain.Entitities;
using ComandApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Domain.Respositories
{
    public interface IProdutoRepository
    {
        void Create(Produto Produto);

        void Update(Produto Produto);

        void Delete(Produto Produto);

        IEnumerable<ListarProdutoViewModel> BuscarTodos();

        IEnumerable<ListarProdutoViewModel> BuscarAtivos();

        IEnumerable<ListarProdutoViewModel> BuscarInativos();
    }
}
