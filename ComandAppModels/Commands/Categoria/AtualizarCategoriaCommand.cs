using Flunt.Notifications;
using System;
using System.Collections.Generic;
using ComandApp.Domain.Contracts;

namespace ComandApp.Domain.Commands
{
    public class AtualizarCategoriaCommand : Notifiable<Notification>
    {
        public AtualizarCategoriaCommand() { }
        public AtualizarCategoriaCommand(string descricao, bool ativo, string iconURL)
        {
            Descricao = descricao;
            Ativo = ativo;
            IconURL = iconURL;

            AddNotifications(new CriarCategoriaContract(this.Descricao, this.IconURL));
        }

        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string IconURL { get; set; }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            throw new NotImplementedException();
        }
    }
}
