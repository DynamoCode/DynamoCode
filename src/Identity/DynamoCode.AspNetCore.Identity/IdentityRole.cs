using Microsoft.AspNetCore.Identity;

namespace DynamoCode.Core.Domain.Identity
{
    public class IdentityRole : IdentityRole<int>
    {
        public IdentityRole()
        { }

        public IdentityRole(string roleName): base(roleName) {

        }
    }
}
