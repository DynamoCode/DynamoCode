using System.Collections.Generic;

namespace DynamoCode.Domain.Data.Interfaces
{
    public interface IReadRepository<TKey, TEntity> where TEntity : class
    {
        TEntity FindBy(TKey id);

        IList<TEntity> All();

        IList<TEntity> All(int page, int itemsPerPage);

        int Count();
    }

    public interface IReadRepository<TEntity> : IReadRepository<int, TEntity> where TEntity : class
    {

    }
}
