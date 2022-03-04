using ComandApp.Domain.Commands;
using ComandApp.Domain.Entitities;
using ComandApp.Domain.ViewModels;
using ComandApp.Infra.Contexts;
using ComandAppApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ComandAppApi.Controllers
{
  /*  [ApiController]
    public class CategoriaControllerOld : ControllerBase
    {

        [HttpGet("v1/categorias")]
        public async Task<IActionResult> GetAsync([FromServices] ComandAppDataContext context,[FromServices] IMemoryCache cache)
        {

            var categorias = await cache.GetOrCreate("CategoriasCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

                return context.Categorias
               .AsNoTracking()
               .Select(x =>
               new ListarCategoriaViewModel
               {
                   Descricao = x.Descricao,
                   Ativo = x.Ativo,
                   iconURL = x.IconURL
               }).ToListAsync();
            });


            return Ok(new ResultViewModel<List<ListarCategoriaViewModel>>(categorias));
        }


        [HttpGet("v1/categorias/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] ComandAppDataContext context)
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Descricao == "");

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost("v1/categorias")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CriarCategoriaViewModel model,
            [FromServices] ComandAppDataContext context)
        {

            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Categoria>(ModelState.GetErrors()));


            try
            {
                var categoria = new CriarCategoriaCommand(model.Descricao, model.Ativo, model.iconURL);


                await context.Categorias.AddAsync(categoria);
                await context.SaveChangesAsync();
                return Created($"v1/categorias/{categoria.Id}", new ResultViewModel<Categoria>(categoria));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<List<Categoria>>("Não foi possível incluir a categoria"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Categoria>>("Falha interna do servidor"));
            }
        }


    }*/
}
