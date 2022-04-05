using ComandApp.Domain.Entitities;
using Flunt.Validations;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComandApp.Domain.Contracts;

namespace ComandApp.Domain.Commands
{
    public class CriarProdutoCommand : Notifiable<Notification>
    {
        public CriarProdutoCommand(string nome, string descricao, bool ativo, int categoriaid)
        {
            Descricao = descricao;
            Ativo = ativo;
            CategoriaId = categoriaid;
            Nome = nome;

            AddNotifications(new CriarProdutoContract(this.Descricao));
        }


        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; }


    }
}
