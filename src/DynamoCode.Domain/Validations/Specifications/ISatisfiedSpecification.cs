namespace DynamoCode.Domain.Validations.Specifications
{
    public interface ISatisfiedSpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
