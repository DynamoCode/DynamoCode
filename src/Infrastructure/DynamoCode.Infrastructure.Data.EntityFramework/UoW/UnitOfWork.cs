using System.Threading.Tasks;
using DynamoCode.Infrastructure.Data.EntityFramework.UoW;
using Microsoft.EntityFrameworkCore;

namespace DynamoCode.Infrastructure.Data.EntityFramework.UoW {
    public class UnitOfWork : DbContext, IEFUnitOfWork {
        public UnitOfWork (DbContextOptions<UnitOfWork> options) : base (options) { }

        public DbContext Context => this;

        public void Commit () {
            SaveChanges ();
        }

        public Task CommitAsync () {
            return SaveChangesAsync ();
        }
    }
}