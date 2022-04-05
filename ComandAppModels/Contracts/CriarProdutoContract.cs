using ComandApp.Domain.Commands;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Domain.Contracts
{
    public class CriarProdutoContract : Contract<CriarProdutoCommand>
    {
        public CriarProdutoContract(string descricao)
        {
            Requires()
                .IsNotNullOrWhiteSpace(descricao, nameof(descricao), "Descrição não pode ser vazia");


        }
    }
}
