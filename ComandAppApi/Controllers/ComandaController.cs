using ComandApp.Domain.Commands;
using ComandApp.Domain.Handlers;
using ComandApp.Domain.Respositories; // For IComandaRepository if needed directly, though likely through Handler
using Microsoft.AspNetCore.Mvc;

namespace ComandAppApi.Controllers
{
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly ComandaHandler _handler; // Directly using handler
        private readonly IComandaRepository _repository; // Or inject repository if direct access is needed for GETs

        // It's common to inject the handler for command operations (POST, PUT, DELETE)
        // and the repository for query operations (GET)
        public ComandaController(ComandaHandler handler, IComandaRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost("v1/comandas")]
        public IActionResult CriarComanda([FromBody] CriarComandaCommand command)
        {
            var result = (GenericCommandResult)_handler.Handle(command);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(400, result);
        }

        [HttpGet("v1/comandas/{id:int}")]
        public IActionResult GetComandaPorId(int id)
        {
            var comanda = _repository.BuscarComandaPorId(id);
            if (comanda == null)
                return NotFound(new GenericCommandResult(false, "Comanda não encontrada", null));
            
            return Ok(new GenericCommandResult(true, "Comanda encontrada", comanda));
        }

        [HttpPost("v1/comandas/{idComanda:int}/produtos")]
        public IActionResult AdicionarProduto(int idComanda, [FromBody] AdicionarProdutoComandaCommand command)
        {
            // Ensure the command's IdComanda matches the route parameter or set it
            if (command.IdComanda == 0) // Or if it's not set by the client
                command.IdComanda = idComanda;
            else if (command.IdComanda != idComanda)
                 return BadRequest(new GenericCommandResult(false, "ID da comanda na rota diverge do corpo da requisição.", null));


            var result = (GenericCommandResult)_handler.Handle(command);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(400, result);
        }

        // Add other actions for:
        // - Removing a product from a comanda
        // - Updating comanda status (e.g., "Em preparo", "Pronto", "Entregue", "Paga")
        // - Listing comandas (e.g., all active, by table, by status)
    }
}
