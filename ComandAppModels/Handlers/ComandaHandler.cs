using ComandApp.Domain.Commands;
using ComandApp.Domain.Entitities;
using ComandApp.Domain.Handlers.Contracts;
using ComandApp.Domain.Respositories;

namespace ComandApp.Domain.Handlers
{
    public class ComandaHandler :
        IHandler<CriarComandaCommand>, // Assuming you'll create this command
        IHandler<AdicionarProdutoComandaCommand> // Assuming you'll create this command
    {
        private readonly IComandaRepository _repository;

        public ComandaHandler(IComandaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CriarComandaCommand command)
        {
            // Validate command (e.g., using Flunt)
            // command.Validate();
            // if (command.Invalid)
            //     return new GenericCommandResult(false, "Ops, parece que sua comanda tem algum problema!", command.Notifications);

            // Create Comanda entity
            var comanda = new Comanda(command.Mesa); // Assuming Comanda has a constructor that takes mesa (table number)

            // Save to repository
            _repository.CriarComanda(comanda);

            return new GenericCommandResult(true, "Comanda criada com sucesso!", comanda);
        }

        public ICommandResult Handle(AdicionarProdutoComandaCommand command)
        {
            // Validate command
            // command.Validate();
            // if (command.Invalid)
            //     return new GenericCommandResult(false, "Ops, parece que o produto na comanda tem algum problema!", command.Notifications);

            // Retrieve Comanda
            var comanda = _repository.BuscarComandaPorId(command.IdComanda);
            if (comanda == null)
                return new GenericCommandResult(false, "Comanda não encontrada!", null);

            // Create ComandaProduto entity
            var comandaProduto = new ComandaProduto(command.IdComanda, command.IdProduto, command.Quantidade, command.Observacao); // Assuming constructor

            // Add product to Comanda (domain logic might be in the Comanda entity itself)
            // comanda.AdicionarProduto(comandaProduto); 

            // Save to repository
            _repository.AdicionarProdutoComanda(comandaProduto);
            
            // _repository.AtualizarComanda(comanda); // Or similar, if AdicionarProdutoComanda doesn't save related Comanda changes

            return new GenericCommandResult(true, "Produto adicionado à comanda com sucesso!", comandaProduto);
        }

        // Implement other handler methods for updating status, removing products, etc.
    }
}
