using ComandApp.Domain.Entitities;
using ComandApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Domain.Respositories
{
    public interface ICategoriaRepository
    {
        void Create(Categoria categoria);

        void Update(Categoria categoria);

        void Delete(Categoria categoria);

        IEnumerable<ListarCategoriaViewModel> BuscarTodos();

        IEnumerable<ListarCategoriaViewModel> BuscarAtivos();

        IEnumerable<ListarCategoriaViewModel> BuscarInativos();

        ListarCategoriaViewModel BuscarPorId(int id, out Categoria? categoria);
    }
}
