using ComandApp.Domain.Entitities;
using ComandApp.Domain.ViewModels;
using ComandApp.Infra.Contexts;
using ComandAppApi.Extensions;
using ComandAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace ComandAppApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("v1/usuarios")]
        public async Task<IActionResult> Post([FromBody] RegistrarViewModel model, [FromServices] ComandAppDataContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }

            var usuario = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                SenhaHash = PasswordHasher.Hash(model.Senha),
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now

            };

            try
            {
                await context.Usuarios!.AddAsync(usuario);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    usuario = usuario.Email
                }));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Falha interna no servidor"));
            }

        }


        [HttpPost("v1/login")]
        public async Task<IActionResult> Login([FromServices] TokenService tokenService, [FromBody] LoginViewModel model, [FromServices] ComandAppDataContext context)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }

            var usuario = await context
                .Usuarios!
                .AsNoTracking()
                .Include(x => x.Permissoes)
                .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (usuario == null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            if(!PasswordHasher.Verify(usuario.SenhaHash, model.Senha))
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            var token = tokenService.GenerateToken(usuario);

            return Ok(new ResultViewModel<string>(token, null));
        }
    }
}
