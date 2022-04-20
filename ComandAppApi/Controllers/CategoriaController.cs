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


        [HttpGet("v2/categorias")]
        public IActionResult GetV2([FromServices] ICategoriaRepository repository)
        {

            var categorias = repository.BuscarTodos();


            return Ok(categorias);
        }


        [HttpGet("v1/categorias/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] ICategoriaRepository repository)
        {

            var categoria = repository.BuscarPorId(id, out Categoria? category);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }




    }
}
