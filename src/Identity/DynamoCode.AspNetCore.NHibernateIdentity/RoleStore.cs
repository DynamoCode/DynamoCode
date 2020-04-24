using DynamoCode.Core.Domain.Identity;
using DynamoCode.Infrastructure.Data.NHibernate;
using DynamoCode.Infrastructure.Data.NHibernate.UoW;
using Microsoft.AspNetCore.Identity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace DynamoCode.AspNetCore.NHibernateIdentity
{
    public class RoleStore<TRole> : IQueryableRoleStore<TRole>, IRoleClaimStore<TRole> where TRole : DynamoCode.Core.Domain.Identity.IdentityRole
    {
        private INHUnitOfWork _unitOfWork;

        public ISession Session
        {
            get
            {
                return _unitOfWork.Session;
            }
        }

        public IdentityErrorDescriber ErrorDescriber { get; set; }

        public RoleStore(
            INHUnitOfWork unitOfWork, IdentityErrorDescriber describer
        )
        {
            _unitOfWork = unitOfWork;
            ErrorDescriber = describer ?? new IdentityErrorDescriber();
        }

        public void Dispose()
        {
        }

        public virtual async Task<IdentityResult> CreateAsync(
            TRole role,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            await Session.SaveAsync(role, cancellationToken);
            return IdentityResult.Success;
        }

        public virtual async Task<IdentityResult> UpdateAsync(
            TRole role,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            var exists = await Roles.AnyAsync<TRole>(
                r => r.Id == role.Id,
                cancellationToken
            );
            if (exists)
            {
                return IdentityResult.Failed();
            }
            role.ConcurrencyStamp = Guid.NewGuid().ToString("N");
            await Session.MergeAsync(role, cancellationToken);
            return IdentityResult.Success;
        }

        public virtual async Task<IdentityResult> DeleteAsync(
            TRole role,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            await Session.DeleteAsync(role, cancellationToken);
            return IdentityResult.Success;
        }

        public virtual Task<string> GetRoleIdAsync(
            TRole role,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            return Task.FromResult(role.Id.ToString());
        }

        public virtual Task<string> GetRoleNameAsync(
            TRole role,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(
            TRole role,
            string roleName,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedRoleNameAsync(
            TRole role,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            return Task.FromResult(role.NormalizedName);
        }

        public Task SetNormalizedRoleNameAsync(
            TRole role,
            string normalizedName,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public async Task<TRole> FindByIdAsync(
            string roleId,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            var id = Convert.ToInt32(roleId);
            var role = await Session.GetAsync<TRole>(id, cancellationToken);
            return role;
        }

        public async Task<TRole> FindByNameAsync(
            string normalizedRoleName,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            var role = await Roles
                .FirstOrDefaultAsync(
                    r => r.NormalizedName == normalizedRoleName,
                    cancellationToken
                );
            return role;
        }

        public virtual IQueryable<TRole> Roles => Session.Query<TRole>();

        private IQueryable<IdentityRoleClaim> RoleClaims => Session.Query<IdentityRoleClaim>();

        public virtual async Task<IList<Claim>> GetClaimsAsync(
            TRole role,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var claims = await RoleClaims
                .Where(rc => rc.RoleId == role.Id)
                .Select(c => new Claim(c.ClaimType, c.ClaimValue))
                .ToListAsync(cancellationToken);
            return claims;
        }

        public virtual async Task AddClaimAsync(
            TRole role,
            Claim claim,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }
            var roleClaim = CreateRoleClaim(role, claim);
            await Session.SaveAsync(roleClaim, cancellationToken);
        }

        public virtual async Task RemoveClaimAsync(
            TRole role,
            Claim claim,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }
            var claims = await RoleClaims.Where(
                    rc => rc.RoleId == role.Id
                        && rc.ClaimValue == claim.Value &&
                        rc.ClaimType == claim.Type
                )
                .ToListAsync(cancellationToken);
            foreach (var c in claims)
            {
                await Session.DeleteAsync(c, cancellationToken);
            }
        }

        protected virtual IdentityRoleClaim CreateRoleClaim(
            TRole role,
            Claim claim
        ) => new IdentityRoleClaim
        {
            RoleId = role.Id,
            ClaimType = claim.Type,
            ClaimValue = claim.Value
        };

    }
}
