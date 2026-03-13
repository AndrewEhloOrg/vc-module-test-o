using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Artem.TestO.Data.Repositories;

namespace Artem.TestO.Data.MySql;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestODbContext>
{
    public TestODbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TestODbContext>();
        var connectionString = args.Length != 0 ? args[0] : "Server=localhost;User=virto;Password=virto;Database=VirtoCommerce3;";

        builder.UseMySql(
            connectionString,
            ResolveServerVersion(args, connectionString),
            options => options.MigrationsAssembly(typeof(MySqlDataAssemblyMarker).Assembly.GetName().Name));

        return new TestODbContext(builder.Options);
    }

    private static ServerVersion ResolveServerVersion(string[] args, string connectionString)
    {
        var serverVersion = args.Length >= 2 ? args[1] : null;

        if (serverVersion == "AutoDetect")
        {
            return ServerVersion.AutoDetect(connectionString);
        }

        if (serverVersion != null)
        {
            return ServerVersion.Parse(serverVersion);
        }

        return new MySqlServerVersion(new Version(5, 7));
    }
}
