using ComandApp.Domain.Commands;
using ComandApp.Domain.Entitities;
using ComandApp.Domain.Handlers;
using ComandApp.Tests.Repositories; // Namespace for FakeComandaRepository
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComandApp.Tests.HandlerTests
{
    [TestClass]
    public class ComandaHandlerTests
    {
        private CriarComandaCommand _validCriarComandaCommand;
        private CriarComandaCommand _invalidCriarComandaCommand;
        private AdicionarProdutoComandaCommand _validAdicionarProdutoCommand;
        private AdicionarProdutoComandaCommand _invalidAdicionarProdutoCommand;
        private ComandaHandler _handler;
        private FakeComandaRepository _fakeRepository;

        public ComandaHandlerTests()
        {
            _fakeRepository = new FakeComandaRepository();
            _handler = new ComandaHandler(_fakeRepository);

            _validCriarComandaCommand = new CriarComandaCommand(10); // Mesa 10
            _invalidCriarComandaCommand = new CriarComandaCommand(0); // Invalid Mesa

            // Pre-populate a comanda for AdicionarProduto tests
            var comandaExistente = new Comanda(1); // Mesa 1
            _fakeRepository.CriarComanda(comandaExistente);


            _validAdicionarProdutoCommand = new AdicionarProdutoComandaCommand(comandaExistente.Id, 1, 2, "Sem cebola"); // Comanda ID 1, Produto ID 1, Qtd 2
            _invalidAdicionarProdutoCommand = new AdicionarProdutoComandaCommand(comandaExistente.Id, 0, 0); // Invalid Produto ID and Qtd
        }

        [TestMethod]
        public void Dado_um_comando_de_criar_comanda_valido_deve_criar_a_comanda()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCriarComandaCommand);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(Comanda));
        }

        [TestMethod]
        public void Dado_um_comando_de_criar_comanda_invalido_nao_deve_criar_a_comanda()
        {
            // Ensure validation is triggered in the command or handler
             _invalidCriarComandaCommand.Validate(); // Assuming command has Validate
            var result = (GenericCommandResult)_handler.Handle(_invalidCriarComandaCommand);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void Dado_um_comando_de_adicionar_produto_valido_deve_adicionar_o_produto()
        {
            var result = (GenericCommandResult)_handler.Handle(_validAdicionarProdutoCommand);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(ComandaProduto));
        }

        [TestMethod]
        public void Dado_um_comando_de_adicionar_produto_a_comanda_inexistente_nao_deve_adicionar()
        {
            var comandoComandaInexistente = new AdicionarProdutoComandaCommand(999, 1, 1); // Comanda ID 999 does not exist
            var result = (GenericCommandResult)_handler.Handle(comandoComandaInexistente);
            Assert.IsFalse(result.Success);
        }
        
        [TestMethod]
        public void Dado_um_comando_de_adicionar_produto_invalido_nao_deve_adicionar_o_produto()
        {
            _invalidAdicionarProdutoCommand.Validate(); // Assuming command has Validate
            var result = (GenericCommandResult)_handler.Handle(_invalidAdicionarProdutoCommand);
            Assert.IsFalse(result.Success);
        }
    }
}
