using ComandApp.Domain.Commands;
using ComandApp.Domain.Entitities;
using ComandApp.Domain.Handlers;
using ComandApp.Domain.Respositories;
using ComandApp.Tests.Repositories; // For FakeComandaRepository
using ComandAppApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq; // Using Moq for mocking handler if needed, or can use real handler with fake repo

namespace ComandApp.Tests.ControllerTests
{
    [TestClass]
    public class ComandaControllerTests
    {
        private ComandaController _controller;
        private FakeComandaRepository _fakeRepository;
        private ComandaHandler _handler; // Using real handler with FakeRepository

        public ComandaControllerTests()
        {
            _fakeRepository = new FakeComandaRepository();
            _handler = new ComandaHandler(_fakeRepository); // Real handler, fake repo
            _controller = new ComandaController(_handler, _fakeRepository); // Inject real handler and fake repo

            // Pre-populate a comanda for GET tests
            var comandaExistente = new Comanda(15); // Mesa 15
            _fakeRepository.CriarComanda(comandaExistente);
        }

        [TestMethod]
        public void CriarComanda_ComandoValido_RetornaOkResult()
        {
            var command = new CriarComandaCommand(20); // Mesa 20
            var result = _controller.CriarComanda(command);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(GenericCommandResult));
            var genericResult = okResult.Value as GenericCommandResult;
            Assert.IsTrue(genericResult.Success);
        }

        [TestMethod]
        public void CriarComanda_ComandoInvalido_RetornaBadRequest()
        {
            var command = new CriarComandaCommand(0); // Invalid Mesa
            // Manually call validate if controller doesn't, or ensure handler does
            command.Validate(); 
            var result = _controller.CriarComanda(command);

            Assert.IsInstanceOfType(result, typeof(ObjectResult)); // StatusCode(400, result) is an ObjectResult
            var badRequestResult = result as ObjectResult;
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.IsNotNull(badRequestResult.Value);
            Assert.IsInstanceOfType(badRequestResult.Value, typeof(GenericCommandResult));
            var genericResult = badRequestResult.Value as GenericCommandResult;
            Assert.IsFalse(genericResult.Success);
        }

        [TestMethod]
        public void GetComandaPorId_IdExistente_RetornaOkResultComComanda()
        {
            var comandaExistente = _fakeRepository.BuscarComandaPorId(1); // Assuming ID 1 was created in constructor
            Assert.IsNotNull(comandaExistente, "Setup falhou: Comanda existente não encontrada no fake repository.");

            var result = _controller.GetComandaPorId(comandaExistente.Id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(GenericCommandResult));
            var genericResult = okResult.Value as GenericCommandResult;
            Assert.IsTrue(genericResult.Success);
            Assert.IsNotNull(genericResult.Data);
            Assert.IsInstanceOfType(genericResult.Data, typeof(Comanda));
        }

        [TestMethod]
        public void GetComandaPorId_IdInexistente_RetornaNotFound()
        {
            var result = _controller.GetComandaPorId(999); // ID 999 does not exist

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
             var notFoundResult = result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult.Value);
            Assert.IsInstanceOfType(notFoundResult.Value, typeof(GenericCommandResult));
            var genericResult = notFoundResult.Value as GenericCommandResult;
            Assert.IsFalse(genericResult.Success);
        }

        [TestMethod]
        public void AdicionarProduto_ComandoValido_RetornaOkResult()
        {
            var comandaExistente = _fakeRepository.BuscarComandaPorId(1); // Assuming ID 1 was created
             Assert.IsNotNull(comandaExistente, "Setup falhou: Comanda existente não encontrada no fake repository.");

            var command = new AdicionarProdutoComandaCommand(comandaExistente.Id, 1, 1, "Com Gelo");
            var result = _controller.AdicionarProduto(comandaExistente.Id, command);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
             Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(GenericCommandResult));
            var genericResult = okResult.Value as GenericCommandResult;
            Assert.IsTrue(genericResult.Success);
        }
        
        [TestMethod]
        public void AdicionarProduto_IdComandaDivergente_RetornaBadRequest()
        {
            var comandaExistente = _fakeRepository.BuscarComandaPorId(1);
            Assert.IsNotNull(comandaExistente, "Setup falhou: Comanda existente não encontrada no fake repository.");

            // ID na rota é 1, ID no comando é 2
            var command = new AdicionarProdutoComandaCommand(2, 1, 1, "Com Gelo"); 
            var result = _controller.AdicionarProduto(comandaExistente.Id, command);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult.Value);
            Assert.IsInstanceOfType(badRequestResult.Value, typeof(GenericCommandResult));
            var genericResult = badRequestResult.Value as GenericCommandResult;
            Assert.IsFalse(genericResult.Success);
            Assert.AreEqual("ID da comanda na rota diverge do corpo da requisição.", genericResult.Message);
        }
    }
}
