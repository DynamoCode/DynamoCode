using Microsoft.AspNetCore.Identity;

namespace DynamoCode.Core.Domain.Identity
{
    public class IdentityUser : IdentityUser<int>
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }
    }
}
