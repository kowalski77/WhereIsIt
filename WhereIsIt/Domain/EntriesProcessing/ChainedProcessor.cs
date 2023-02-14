using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.EntriesProcessing;

internal class ChainedProcessor : IEntryProcessor
{
    private IEntryProcessor Inner { get; }

    private IEntryProcessor Next { get; }

    public ChainedProcessor(IEntryProcessor inner, IEntryProcessor next)
    {
        this.Inner = inner;
        this.Next = next;
    }

    public IEnumerable<Entry?> Execute(IEnumerable<Line> lines) => Inner.Execute(lines);
}
