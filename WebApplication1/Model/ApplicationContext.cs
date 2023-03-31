using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model;

public class ApplicationContext : DbContext
{
    public  DbSet<Brand> Brands { get; set; }
    private string _connectionString;

    public ApplicationContext(string connectionString)
    {
        _connectionString = connectionString;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}