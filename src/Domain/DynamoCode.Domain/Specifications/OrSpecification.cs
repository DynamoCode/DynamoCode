﻿namespace DynamoCode.Domain.Specifications
{
    public class OrSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first;

        private ISpecification<T> second;

        public OrSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return first.IsSatisfiedBy(entity) || second.IsSatisfiedBy(entity);
        }
    }
}