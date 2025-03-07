using Microsoft.EntityFrameworkCore;

namespace PokemonApi.Infrastructure;

public class RelationlDbContext : DbContext
{
    public DbSet<PokemonEntity> Pokemons { get; set; }
    public RelationlDbContext(DbContextOptions<RelationlDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PokemonEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Level).IsRequired();
            entity.Property(e => e.Attack).IsRequired();
            entity.Property(e => e.Defense).IsRequired();
            entity.Property(e => e.Speed).IsRequired();
        });
    }
}