using DynamoCode.Infrastructure.Data;
using DynamoCode.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamoCode.Application
{
    public class ReadOnlyServices<T> where T : class
    {
        protected IReadOnlyRepository<T> _readOnlyRepository;

        public ReadOnlyServices(IReadOnlyRepository<T> repository)
        {
            _readOnlyRepository = repository;
        }

        public T FindBy(int id)
        {
            return _readOnlyRepository.FindBy(id);
        }

        public IList<T> All()
        {
            return _readOnlyRepository.All();
        }

        public PagedResult<T> All(int page, int itemsPerPage)
        {
            return _readOnlyRepository.All(page, itemsPerPage);
        }

        public Task<T> FindByAsync(int id)
        {
            return _readOnlyRepository.FindByAsync(id);
        }

        public Task<List<T>> AllAsync()
        {
            return _readOnlyRepository.AllAsync();
        }

        public Task<PagedResult<T>> AllAsync(int page, int itemsPerPage)
        {
            return _readOnlyRepository.AllAsync(page, itemsPerPage);
        }
    }
}
