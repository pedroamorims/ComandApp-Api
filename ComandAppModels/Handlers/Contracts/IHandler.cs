using ComandApp.Domain.Contracts;
using Flunt.Notifications;

namespace ComandApp.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : Notifiable<Notification>
    {
        ICommandResult Handle(T command);
    }
}
