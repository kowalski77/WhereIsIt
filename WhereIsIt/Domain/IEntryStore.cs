using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain;

internal interface IEntryStore
{
    IEnumerable<Entry> GetEntries();

    void RemoveAll();

    void Save(IEnumerable<Entry> entries);
}
