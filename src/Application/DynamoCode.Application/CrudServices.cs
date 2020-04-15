using DynamoCode.Application.Mappers;
using DynamoCode.Infrastructure.Data;
using System.Threading.Tasks;

namespace DynamoCode.Application
{
    public class CrudServices<Entity,EntityDto> : ReadOnlyServices<Entity, EntityDto> where Entity : class
    {
        private IUnitOfWork _unitOfWork;

        private IRepository<Entity> _repository;

        public CrudServices(IRepository<Entity> repository,
                            IMapper<Entity,EntityDto> mapper,
                            IUnitOfWork unitOfWork)
            : base(repository,mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(EntityDto entityDto)
        {
            var entity = _mapper.MapToEntity(entityDto);
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Update(EntityDto entityDto)
        {
            var entity = _mapper.MapToEntity(entityDto);
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Commit();
        }

        public async Task AddAsync(EntityDto entityDto)
        {
            var entity = _mapper.MapToEntity(entityDto);
            _repository.Add(entity);
             await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(EntityDto entityDto)
        {
            var entity = _mapper.MapToEntity(entityDto);
            _repository.Update(entity);
             await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _repository.Delete(id);
             await _unitOfWork.CommitAsync();
        }
    }
}
