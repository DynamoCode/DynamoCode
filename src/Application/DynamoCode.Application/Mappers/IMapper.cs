namespace DynamoCode.Application.Mappers
{
    public interface IMapper<Entity,EntityDto>
    {
       EntityDto MapToDto(Entity entity);

       Entity MapToEntity(EntityDto entity);
    }
}