using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.EntriesProcessing;

internal abstract class RuleBasedProcessor : IEntryProcessor
{
    protected abstract IMultiwaySplitter Splitter { get; }

    public IEnumerable<Entry?> Execute(IEnumerable<Line> lines) =>
        lines.Select(this.Splitter.ApplyTo);
}

internal class SplitProcessor : RuleBasedProcessor
{
    protected override IMultiwaySplitter Splitter => 
        new SemicolonSpliter()
        .Append(new ComaSpliter());
}

internal class SemicolonSpliter : IMultiwaySplitter
{
    public Entry? ApplyTo(Line line)
    {
        var parts = line.Value.Split(';');
        if (parts.Length < 2)
        {
            return null;
        }

        return Entry.New(parts[0], parts[1], parts[2]);
    }
}

internal class ComaSpliter : IMultiwaySplitter
{
    public Entry? ApplyTo(Line line)
    {
        var parts = line.Value.Split(',');
        if (parts.Length < 2)
        {
            return null;
        }

        return Entry.New(parts[0], parts[1], parts[2]);
    }
}
