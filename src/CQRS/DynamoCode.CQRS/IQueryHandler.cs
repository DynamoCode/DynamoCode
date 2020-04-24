using System.Threading.Tasks;

namespace DynamoCode.CQRS
{
    public interface IQueryHandler<TQuery,TResult> where TQuery: IQuery<TResult>
    {
        TResult HandleAsync(TQuery query);
    }

    public interface IQueryHandlerAsync<TQuery,TResult> where TQuery: IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}