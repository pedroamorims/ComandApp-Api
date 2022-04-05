using ComandApp.Domain.Commands;
using ComandApp.Domain.Entitities;
using ComandApp.Domain.Handlers;
using ComandApp.Domain.Respositories;
using ComandApp.Domain.ViewModels;
using ComandApp.Infra.Contexts;
using ComandAppApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ComandAppApi.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        [HttpPost("v1/Produtos")]
        public IActionResult Post([FromBody] CriarProdutoCommand command, [FromServices] ProdutoHandler handler)
        {


            GenericCommandResult resultado = (GenericCommandResult)handler.Handle(command);

            if (resultado.Success)
            {
                return (Ok(resultado));
            }
            else
            {
                return StatusCode(400, resultado);
            }


        }


        [HttpGet("v1/Produtos")]
        public IActionResult Get([FromServices] IProdutoRepository repository, [FromServices] IMemoryCache cache)
        {

            var Produtos = repository.BuscarTodos();


            return Ok(Produtos);
        }


        [HttpGet("v1/Produtos/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] ComandAppDataContext context)
        {
            var Produto = await context.Produtos!.FirstOrDefaultAsync(x => x.Id == id);

            if (Produto == null)
                return NotFound();

            return Ok(Produto);
        }




    }
}
