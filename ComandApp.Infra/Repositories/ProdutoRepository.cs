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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ComandAppDataContext _context;

        public ProdutoRepository(ComandAppDataContext context)
        {
            _context = context;
        }

        public void Create(Produto Produto)
        {
            _context.Produtos!.Add(Produto);
            _context.SaveChanges();
        }

        public void Delete(Produto Produto)
        {
            _context.Entry(Produto).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(Produto Produto)
        {
            _context.Entry(Produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<ListarProdutoViewModel> BuscarTodos()
        {
            return _context.Produtos!
                    .AsNoTracking()
                    .Select(x =>
                    new ListarProdutoViewModel
                    {
                        Id = x.Id,
                        Descricao = x.Descricao,
                        Nome = x.Nome,
                        Ativo = x.Ativo,
                        Categoria = new ListarCategoriaViewModel
                        {
                            Id = x.Categoria.Id,
                            Descricao = x.Categoria.Descricao,
                            Ativo = x.Categoria.Ativo,
                            iconURL = x.Categoria.IconURL
                        }
                    }).ToList();
        }

        public IEnumerable<ListarProdutoViewModel> BuscarAtivos()
        {
            return _context.Produtos!.AsNoTracking().Select(x =>
                  new ListarProdutoViewModel
                  {
                      Id = x.Id,
                      Descricao = x.Descricao,
                      Ativo = x.Ativo
                  }).Where(x => x.Ativo == true).ToList();
        }

        public IEnumerable<ListarProdutoViewModel> BuscarInativos()
        {
            return _context.Produtos!.AsNoTracking().Select(x =>
                  new ListarProdutoViewModel
                  {
                      Id = x.Id,
                      Descricao = x.Descricao,
                      Ativo = x.Ativo
                  }).Where(x => x.Ativo == true).ToList();
        }


    }
}
