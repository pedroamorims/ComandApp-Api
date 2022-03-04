using ComandApp.Domain.Entitities;
using System.Security.Claims;

namespace ComandAppApi.Extensions
{
    public static class PermissoesClaimUsuario
    {
        public static IEnumerable<Claim> GetClaims(this Usuario usuario)
        {
            var result = new List<Claim>()
            {
                new(ClaimTypes.Name, usuario.Nome)
            };

            result.AddRange(usuario.Permissoes.Select(permissao => new Claim(ClaimTypes.Role, permissao.Descricao)));

            return result;
        }
    }
}
