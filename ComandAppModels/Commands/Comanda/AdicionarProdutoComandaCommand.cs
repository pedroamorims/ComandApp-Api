using ComandApp.Domain.Contracts; // Assuming ICommand is here
using Flunt.Notifications;
using Flunt.Validations;

namespace ComandApp.Domain.Commands
{
    public class AdicionarProdutoComandaCommand : Notifiable, ICommand
    {
        public AdicionarProdutoComandaCommand() { }

        public AdicionarProdutoComandaCommand(int idComanda, int idProduto, int quantidade, string observacao = null)
        {
            IdComanda = idComanda;
            IdProduto = idProduto;
            Quantidade = quantidade;
            Observacao = observacao;
        }

        public int IdComanda { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(IdComanda, 0, "IdComanda", "O ID da comanda deve ser maior que zero!")
                    .IsGreaterThan(IdProduto, 0, "IdProduto", "O ID do produto deve ser maior que zero!")
                    .IsGreaterThan(Quantidade, 0, "Quantidade", "A quantidade deve ser maior que zero!")
            );
        }
    }
}
