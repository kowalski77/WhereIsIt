using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.EntriesProcessing;

internal class DoNothing : IEntryProcessor
{
    public IEnumerable<Entry> Execute(IEnumerable<Line> lines) => Enumerable.Empty<Entry>();
}
