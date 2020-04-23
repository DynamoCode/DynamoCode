using System;
using System.Collections.Generic;
using System.Text;

namespace DynamoCode.Domain.Validations.Specifications
{
    public class OrSatisfiedSpecification<T> : ISatisfiedSpecification<T>
    {
        private ISatisfiedSpecification<T> first;

        private ISatisfiedSpecification<T> second;

        public OrSatisfiedSpecification(ISatisfiedSpecification<T> first, ISatisfiedSpecification<T> second)
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
