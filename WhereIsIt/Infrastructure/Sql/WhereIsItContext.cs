using Microsoft.EntityFrameworkCore;
using WhereIsIt.Domain.Models;

namespace WhereIsIt.Infrastructure.Sql;

internal class WhereIsItContext : DbContext
{
    public WhereIsItContext(DbContextOptions options) : base(options) { }

    public WhereIsItContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(SqlConstants.DataSource);
    }

    public DbSet<Entry> Entries { get; set; }
}
