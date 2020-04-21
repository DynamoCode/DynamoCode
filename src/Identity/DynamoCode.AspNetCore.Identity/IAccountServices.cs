using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DynamoCode.AspNetCore.Identity
{
    public interface IAccountServices
    {
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure);

        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
    }
}
