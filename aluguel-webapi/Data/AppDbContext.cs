using Microsoft.EntityFrameworkCore;
using aluguel_webapi.Entities;

namespace aluguel_webapi.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Aluguel> Alugueis { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluguel>().ToTable("alugueis");
        modelBuilder.Entity<Aluguel>().HasKey(a => a.Id); 
    }
}
