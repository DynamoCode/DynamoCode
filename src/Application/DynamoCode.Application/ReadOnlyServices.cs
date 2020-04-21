using DynamoCode.Domain.Entities;
using DynamoCode.Domain.Mappers;
using DynamoCode.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoCode.Application
{
    public class ReadOnlyServices<Entity,EntityDto> where Entity : class
    {
        protected IReadOnlyRepository<Entity> _readOnlyRepository;

        protected IMapper<Entity,EntityDto> _mapper;

        public ReadOnlyServices(IReadOnlyRepository<Entity> repository,
                                IMapper<Entity,EntityDto> mapper)
        {
            _readOnlyRepository = repository;
            _mapper = mapper;
        }

        public EntityDto FindBy(int id)
        {
            var entity = _readOnlyRepository.FindBy(id);
            return _mapper.MapToDto(entity);
        }

        public IList<EntityDto> All()
        {
            return _readOnlyRepository.All().Select(e => _mapper.MapToDto(e)).ToList();
        }        

        public PagedResult<EntityDto> All(int page, int itemsPerPage)
        {
            var items = _readOnlyRepository.All(page, itemsPerPage).Select(e => _mapper.MapToDto(e));
            int count = _readOnlyRepository.Count();

            return new PagedResult<EntityDto>{
                PageOfItems = items.ToList(),
                TotalItems = count
            };
        }

        public async Task<EntityDto> FindByAsync(int id)
        {
            var entity = await  _readOnlyRepository.FindByAsync(id);
            return  _mapper.MapToDto(entity);
        }

        public async Task<List<EntityDto>> AllAsync()
        {
            var items = await _readOnlyRepository.AllAsync();
            return items.Select(e => _mapper.MapToDto(e)).ToList();
        }

        public async Task<PagedResult<EntityDto>> AllAsync(int page, int itemsPerPage)
        {
           var items = await _readOnlyRepository.AllAsync(page, itemsPerPage);
            int count = await _readOnlyRepository.CountAsync();

            return new PagedResult<EntityDto>{
                PageOfItems = items.Select(e => _mapper.MapToDto(e)).ToList(),
                TotalItems = count
            };
        }
    }
}
