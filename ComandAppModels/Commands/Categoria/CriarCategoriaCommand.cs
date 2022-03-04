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
    public class CriarCategoriaCommand : Notifiable<Notification>
    {
        public CriarCategoriaCommand(string descricao, bool ativo, string iconURL)
        {
            Descricao = descricao;
            Ativo = ativo;
            IconURL = iconURL;

            AddNotifications(new CriarCategoriaContract(this.Descricao, this.IconURL));
        }

        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string IconURL { get; set; }

    }
}
