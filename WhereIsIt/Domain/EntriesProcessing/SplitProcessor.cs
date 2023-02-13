using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.EntriesProcessing;

internal abstract class SplitProcessor : IEntryProcessor
{
    public IEnumerable<Entry> Execute(IEnumerable<Line> lines)
    {
        foreach (Line line in lines)
        {
            var parts = line.Value.Split(this.Separator());
            if (parts.Length < 2)
            {
                continue;
            }

            yield return Entry.New(parts[0], parts[1], parts[2]);
        }
    }

    protected abstract Func<char> Separator { get; }
}
