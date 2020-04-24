using System;
using System.Collections.Generic;
using System.Text;

namespace DynamoCode.Domain.Entities
{
    public class PagedResult<T>
    {
        public int TotalItems { get; set; }

        public IList<T> PageOfItems { get; set; }
    }
}
