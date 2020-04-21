using Microsoft.AspNetCore.Identity;

namespace DynamoCode.Core.Domain.Identity
{
    public class IdentityUserRole : IdentityUserRole<int>
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
