using ComandApp.Domain.Commands;
using ComandApp.Domain.Handlers;
using ComandApp.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComandApp.Tests.Models
{
    [TestClass]
    public class CategoriaHandlerTests
    {
        private readonly CriarCategoriaCommand _invalidCommand = new CriarCategoriaCommand("", true, "teste");
        private readonly CriarCategoriaCommand _validCommand = new CriarCategoriaCommand("Bebidas", true, "http://www.teste.com");
        private readonly CategoriaHandler _handler = new CategoriaHandler(new FakeCategoriaRepository());
        private GenericCommandResult _result = new GenericCommandResult();


        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_categoria()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }


    }
}
