using ComandApp.Domain.Commands;
using ComandApp.Domain.Contracts;
using ComandApp.Domain.Entitities;
using ComandApp.Domain.Handlers.Contracts;
using ComandApp.Domain.Respositories;
using ComandApp.Domain.ViewModels;
using Flunt.Notifications;
using System;


namespace ComandApp.Domain.Handlers
{
    public class ProdutoHandler : Notifiable<Notification>, IHandler<CriarProdutoCommand>
    {
        private readonly IProdutoRepository _repository;
        private readonly ICategoriaRepository _repositorycategoria;

        public ProdutoHandler(IProdutoRepository repository, ICategoriaRepository repositorycategoria)
        {
            _repository = repository;
            _repositorycategoria = repositorycategoria;
        }
        public ICommandResult Handle(CriarProdutoCommand command)
        {
            //Fail Fast Validation
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, parece que sua Produto esta errada", command.Notifications);

            var Produto = new Produto(command.Nome, command.Descricao, command.Ativo);

            ListarCategoriaViewModel listarCategoria = _repositorycategoria.BuscarPorId(command.CategoriaId, out Categoria? categoria);

            if (categoria == null)
            {
                return new GenericCommandResult(false, "Ops, categoria informada não foi encontrada", command.CategoriaId);
            }




            Produto.defineCategoria(categoria);

            //Salvar no banco
            _repository.Create(Produto);


            //Retornar resultado
            return new GenericCommandResult(true, "Produto Salvo", new ListarProdutoViewModel
            {
                Id = Produto.Id,
                Descricao = Produto.Descricao,
                Nome = Produto.Nome,
                Ativo = Produto.Ativo
            });



        }

    }
}
