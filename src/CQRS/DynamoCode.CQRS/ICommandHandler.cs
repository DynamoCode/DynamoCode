using System.Threading.Tasks;

namespace DynamoCode.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand model);
    }

    public interface ICommandHandlerAsync<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand model);
    }
}