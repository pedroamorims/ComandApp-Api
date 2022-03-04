using ComandApp.Domain.Entitities;
using ComandApp.Domain.Respositories;
using ComandApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Tests.Repositories
{
    public class FakeCategoriaRepository : ICategoriaRepository
    {
        public IEnumerable<ListarCategoriaViewModel> BuscarAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListarCategoriaViewModel> BuscarInativos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListarCategoriaViewModel> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Create(Categoria categoria)
        {

        }

        public void Delete(Categoria categoria)
        {

        }

        public void Update(Categoria categoria)
        {

        }
    }
}
