using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WhereIsIt.Infrastructure.Sql;

internal class DesignTimeContextFactory : IDesignTimeDbContextFactory<WhereIsItContext>
{
    public WhereIsItContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<WhereIsItContext> optionsBuilder = new();
        optionsBuilder.UseSqlite(SqlConstants.DataSource);

        return new WhereIsItContext(optionsBuilder.Options);
    }
}
