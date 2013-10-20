using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Atlas.Infrastructure.EF
{
    public interface IDbContext
    {
        DbSet<TEntity> Entity<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Database Database { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
