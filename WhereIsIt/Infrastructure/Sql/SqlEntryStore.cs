using WhereIsIt.Domain;
using WhereIsIt.Domain.Models;

namespace WhereIsIt.Infrastructure.Sql;

internal class SqlEntryStore : IEntryStore
{
    private WhereIsItContext Context { get; }

    public SqlEntryStore(WhereIsItContext context) => this.Context = context;

    public void RemoveAll() => this.Context.Entries.RemoveRange(this.Context.Entries);

    public void Save(IEnumerable<Entry> entries) => this.Context.Entries.AddRange(entries);

    public IEnumerable<Entry> GetEntries() => this.Context.Entries;
}
