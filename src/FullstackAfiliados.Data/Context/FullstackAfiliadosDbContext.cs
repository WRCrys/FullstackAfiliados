using FullstackAfiliados.Business.Models;
using FullstackAfiliados.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Data.Context;

public class FullstackAfiliadosDbContext : DbContext
{
    public FullstackAfiliadosDbContext(DbContextOptions<FullstackAfiliadosDbContext> options) : base(options) { }

    public DbSet<Transaction> Transactions { get; set; }
    
    public DbSet<TransactionType> TransactionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetProperties()
                         .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FullstackAfiliadosDbContext).Assembly);
        
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys())) 
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        
        TransactionTypeSeed.RegisterTransactionType(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreatedAt").IsModified = false;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}