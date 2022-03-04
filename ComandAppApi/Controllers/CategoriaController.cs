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
    public class CategoriaController : ControllerBase
    {

        [HttpPost("v1/categorias")]
        public IActionResult Post([FromBody] CriarCategoriaCommand command, [FromServices] CategoriaHandler handler)
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

        [HttpGet("v1/categorias")]
        public IActionResult Get([FromServices] ICategoriaRepository repository, [FromServices] IMemoryCache cache)
        {

            var categorias =  cache.GetOrCreate("CategoriasCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

                return repository.BuscarTodos();
            });


            return Ok(categorias);
        }


        [HttpGet("v1/categorias/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] ComandAppDataContext context)
        {
            var categoria = await context.Categorias!.FirstOrDefaultAsync(x => x.Descricao == "");

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }




    }
}
