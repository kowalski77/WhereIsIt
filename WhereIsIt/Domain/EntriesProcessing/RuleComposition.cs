using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.EntriesProcessing;

internal static class RuleComposition
{
    public static IMultiwaySplitter Append(this IMultiwaySplitter head, IMultiwaySplitter tail) =>
        new AppendSplitter(head, tail);
}

internal class AppendSplitter : IMultiwaySplitter
{
    private IMultiwaySplitter Head { get; }

    private IMultiwaySplitter Tail { get; }

    public AppendSplitter(IMultiwaySplitter head, IMultiwaySplitter tail)
    {
        this.Head = head;
        this.Tail = tail;
    }

    public Entry? ApplyTo(Line line) => this.Head.ApplyTo(line) ?? this.Tail.ApplyTo(line);
}
