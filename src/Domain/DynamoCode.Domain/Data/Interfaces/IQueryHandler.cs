using System.Threading.Tasks;

namespace DynamoCode.Infrastructure.Data.Interfaces
{
    public interface IQueryHandler<TReturn>
    {
        TReturn Execute();
    }

    public interface IQueryHandler<TOptions,TReturn>
    {
        TReturn Execute(TOptions options);
    }

    public interface IQueryHandlerAsync<TReturn>
    {
        Task<TReturn> ExecuteAsync();
    }

    public interface IQueryHandlerAsync<TOptions, TReturn>
    {
        Task<TReturn> ExecuteAsync(TOptions options);
    }
}
