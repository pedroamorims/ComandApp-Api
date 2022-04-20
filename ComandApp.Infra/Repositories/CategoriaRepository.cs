using ComandApp.Domain.Entitities;
using ComandApp.Domain.Respositories;
using ComandApp.Domain.ViewModels;
using ComandApp.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ComandAppDataContext _context;

        public CategoriaRepository(ComandAppDataContext context)
        {
            _context = context;
        }

        public void Create(Categoria categoria)
        {
            _context.Categorias!.Add(categoria);
            _context.SaveChanges();
        }

        public void Delete(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<ListarCategoriaViewModel> BuscarTodos()
        {
            return _context.Categorias!
                    .AsNoTracking()
                    .Select(x =>
                    new ListarCategoriaViewModel
                    {
                        Id = x.Id,
                        Descricao = x.Descricao,
                        Ativo = x.Ativo,
                        iconURL = x.IconURL
                    }).ToList();
        }

        public IEnumerable<ListarCategoriaViewModel> BuscarAtivos()
        {
            return _context.Categorias!.AsNoTracking().Select(x =>
                  new ListarCategoriaViewModel
                  {
                      Id = x.Id,
                      Descricao = x.Descricao,
                      Ativo = x.Ativo,
                      iconURL = x.IconURL
                  }).Where(x => x.Ativo == true).ToList();
        }

        public IEnumerable<ListarCategoriaViewModel> BuscarInativos()
        {
            return _context.Categorias!.AsNoTracking().Select(x =>
                  new ListarCategoriaViewModel
                  {
                      Id = x.Id,
                      Descricao = x.Descricao,
                      Ativo = x.Ativo,
                      iconURL = x.IconURL
                  }).Where(x => x.Ativo == true).ToList();
        }

        public ListarCategoriaViewModel? BuscarPorId(int id, out Categoria? categoria)
        {
            categoria = _context.Categorias!.FirstOrDefault(x => x.Id == id);

            if (categoria != null)
            {
                return new ListarCategoriaViewModel
                {
                    Id = categoria.Id,
                    Descricao = categoria.Descricao,
                    Ativo = categoria.Ativo,
                    iconURL = categoria.IconURL
                };
            }

            else
            {
               return null;
            }

        }

    }
}
