using ComandApp.Domain.Contracts; // Assuming ICommand is here or in a similar namespace
using Flunt.Notifications;
using Flunt.Validations;

namespace ComandApp.Domain.Commands
{
    public class CriarComandaCommand : Notifiable, ICommand
    {
        public CriarComandaCommand() { }

        public CriarComandaCommand(int mesa)
        {
            Mesa = mesa;
        }

        public int Mesa { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Mesa, 0, "Mesa", "O número da mesa deve ser maior que zero!")
            );
        }
    }
}
