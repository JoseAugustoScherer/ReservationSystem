using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entities.Base;
using ReservationSystem.Domain.Interfaces;
using ReservationSystem.Infrastructure.Persistence;

namespace ReservationSystem.Infrastructure.Repositories;

public class UnitOfWork (AppDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        return dbContext.SaveChangesAsync(cancellationToken);
    }
    
    private void UpdateAuditableEntities()
    {
        var entries = dbContext.ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if(entry.State == EntityState.Added)
                entry.Entity.CreatedAt = DateTime.UtcNow;
            
            if (entry.State == EntityState.Modified)
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            
            entry.Property(x => x.CreatedAt).IsModified = false;
        }
    }
}