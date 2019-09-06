namespace DynamoCode.Domain.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T Entity);
    }
}
