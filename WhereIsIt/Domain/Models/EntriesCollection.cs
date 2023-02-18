using System.Collections;

namespace WhereIsIt.Domain.Models;

internal class EntriesCollection : IReadOnlyList<Entry>
{
    private readonly List<Entry> entries;

    public EntriesCollection(IEnumerable<Entry> entries) => this.entries = entries.ToList();

    public Entry this[int index] => this.entries[index];

    public int Count => this.entries.Count;

    public IEnumerator<Entry> GetEnumerator() => this.entries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>this.GetEnumerator();
}
