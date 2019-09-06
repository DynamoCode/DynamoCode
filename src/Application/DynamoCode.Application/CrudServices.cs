using DynamoCode.Infrastructure.Data;
using System.Threading.Tasks;

namespace DynamoCode.Application
{
    public class CrudServices<T> : ReadOnlyServices<T> where T : class
    {
        private IUnitOfWork _unitOfWork;

        private IRepository<T> _repository;

        public CrudServices(IRepository<T> repository, IUnitOfWork unitOfWork)
            : base(repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Commit();
        }

        public Task<int> AddAsync(T entity)
        {
            _repository.Add(entity);
            return _unitOfWork.CommitAsync();
        }

        public Task<int> UpdateAsync(T entity)
        {
            _repository.Update(entity);
            return _unitOfWork.CommitAsync();
        }

        public Task<int> DeleteAsync(int id)
        {
            _repository.Delete(id);
            return _unitOfWork.CommitAsync();
        }
    }
}
