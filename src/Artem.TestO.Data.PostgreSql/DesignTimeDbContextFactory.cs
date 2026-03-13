using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Artem.TestO.Data.Repositories;

namespace Artem.TestO.Data.PostgreSql;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestODbContext>
{
    public TestODbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TestODbContext>();
        var connectionString = args.Length != 0 ? args[0] : "Server=localhost;Username=virto;Password=virto;Database=VirtoCommerce3;";

        builder.UseNpgsql(
            connectionString,
            options => options.MigrationsAssembly(typeof(PostgreSqlDataAssemblyMarker).Assembly.GetName().Name));

        return new TestODbContext(builder.Options);
    }
}
