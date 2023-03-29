using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model;

public class ApplicationContext : DbContext
{
    public  DbSet<Brand> Brands { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=192.168.100.6;Port=5432;Database=pi;Username=postgres;Password=postgres");
    }
}