using b3.DeveloperEvaluation.Domain.Entity;
using b3.DeveloperEvaluation.ORM.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace b3.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<CDB> Cdbs { get; set; }
    public DbSet<Titulo> Titulos { get; set; }


    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfiguration(new CDBConfiguration());
        modelBuilder.ApplyConfiguration(new  TituloConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly("b3.DeveloperEvaluation.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}
