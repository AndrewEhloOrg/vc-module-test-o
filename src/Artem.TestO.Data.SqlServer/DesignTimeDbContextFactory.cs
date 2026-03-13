using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Artem.TestO.Data.Repositories;

namespace Artem.TestO.Data.SqlServer;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestODbContext>
{
    public TestODbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TestODbContext>();
        var connectionString = args.Length != 0 ? args[0] : "Server=(local);User=virto;Password=virto;Database=VirtoCommerce3;";

        builder.UseSqlServer(
            connectionString,
            options => options.MigrationsAssembly(typeof(SqlServerDataAssemblyMarker).Assembly.GetName().Name));

        return new TestODbContext(builder.Options);
    }
}
