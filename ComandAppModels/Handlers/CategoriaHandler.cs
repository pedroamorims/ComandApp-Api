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
    public class CategoriaHandler : Notifiable<Notification>, IHandler<CriarCategoriaCommand>, IHandler<AtualizarCategoriaCommand>
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CriarCategoriaCommand command)
        {
            //Fail Fast Validation
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, parece que sua categoria esta errada", command.Notifications);

            var categoria = new Categoria(command.Descricao, command.Ativo, command.IconURL);

            //Salvar no banco
            _repository.Create(categoria);


            //Retornar resultado
            return new GenericCommandResult(true, "Categoria Salva", new ListarCategoriaViewModel
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao,
                Ativo = categoria.Ativo,
                iconURL = categoria.IconURL
            });

    

        }

        public ICommandResult Handle(AtualizarCategoriaCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
