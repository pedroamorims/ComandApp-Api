using ComandApp.Domain.Commands;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Domain.Contracts
{
    public class CriarCategoriaContract : Contract<CriarCategoriaCommand>
    {
        public CriarCategoriaContract(string descricao, string iconURL)
        {
            Requires()
                .IsNotNullOrWhiteSpace(descricao, nameof(descricao),"Descrição não pode ser vazia")
                .IsUrl(iconURL, nameof(iconURL),"Icon tem que ser uma URL");
         
        }
    }
}
