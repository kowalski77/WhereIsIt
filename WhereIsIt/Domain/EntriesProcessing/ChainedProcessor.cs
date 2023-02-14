using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.EntriesProcessing;

internal class ChainedProcessor : IEntryProcessor
{
    private IEntryProcessor Head { get; }

    private IEntryProcessor Tail { get; }

    public ChainedProcessor(IEntryProcessor head, IEntryProcessor tail)
    {
        this.Head = head;
        this.Tail = tail;
    }

    public IEnumerable<Entry> Execute(IEnumerable<Line> lines) =>
        this.Head.Execute(lines).Concat(this.Tail.Execute(lines));
}

internal static class ChainConstruction
{
    public static IEntryProcessor Append(this IEntryProcessor head, IEntryProcessor tail) =>
        new ChainedProcessor(head, tail);
}
