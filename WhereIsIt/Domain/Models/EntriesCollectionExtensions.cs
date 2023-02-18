namespace WhereIsIt.Domain.Models;

internal static class EntriesCollectionExtensions
{
    public static EntriesCollection ToCollection(this IEnumerable<Entry> entries) => new(entries);
}