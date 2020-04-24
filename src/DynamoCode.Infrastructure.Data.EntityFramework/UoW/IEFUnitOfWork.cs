using DynamoCode.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DynamoCode.Infrastructure.Data.EntityFramework.UoW {
    public interface IEFUnitOfWork : IUnitOfWork {
        DbContext Context { get; }
    }
}