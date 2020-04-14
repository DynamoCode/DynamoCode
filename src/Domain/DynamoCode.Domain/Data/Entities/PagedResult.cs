using System.Collections.Generic;

namespace DynamoCode.Infrastructure.Data.Entities
{
    public class PagedResult<T>
    {
        public int TotalItems { get; set; }

        public IList<T> PageOfItems { get; set; }
    }
}
