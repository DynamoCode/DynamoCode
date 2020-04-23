using System.Collections.Generic;

namespace DynamoCode.Infrastructure.Data
{
    public interface IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        TEntity FindBy(TKey id);

        IList<TEntity> All();

        IList<TEntity> All(int page, int itemsPerPage);

        int Count();
    }

    public interface IReadOnlyRepository<TEntity> : IReadOnlyRepository<int, TEntity> where TEntity : class
    {

    }
}
