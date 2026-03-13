using System.Reflection;
using Microsoft.EntityFrameworkCore;
//using VirtoCommerce.Platform.Data.Extensions;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace Artem.TestO.Data.Repositories;

public class TestODbContext : DbContextBase
{
    public TestODbContext(DbContextOptions<TestODbContext> options)
        : base(options)
    {
    }

    protected TestODbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<TestOEntity>().ToAuditableEntityTable("TestO");

        switch (Database.ProviderName)
        {
            case "Pomelo.EntityFrameworkCore.MySql":
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Artem.TestO.Data.MySql"));
                break;
            case "Npgsql.EntityFrameworkCore.PostgreSQL":
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Artem.TestO.Data.PostgreSql"));
                break;
            case "Microsoft.EntityFrameworkCore.SqlServer":
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Artem.TestO.Data.SqlServer"));
                break;
        }
    }
}
