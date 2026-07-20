using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entities.Base;
using ReservationSystem.Domain.Interfaces;
using ReservationSystem.Infrastructure.Persistence;

namespace ReservationSystem.Infrastructure.Repositories;

public class Repository<TEntity>(AppDbContext dbContext) : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty", nameof(id));
        
        return await dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
}