using Microsoft.EntityFrameworkCore;
using TerceiroSetor.Domain.Entities;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;

namespace TerceiroSetor.Data
{
    public class TerceiroSetorDbContext : DbContext
    {
        public TerceiroSetorDbContext(DbContextOptions options) : base(options) { }

        public DbSet<OrganizacaoSocial> OrganizacoesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAutoscaleThroughput(1000);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TerceiroSetorDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntidadeBase
                            && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Modified)
                    ((EntidadeBase)entityEntry.Entity).DataAtualizacao = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    ((EntidadeBase)entityEntry.Entity).DataCriacao = DateTime.Now;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
