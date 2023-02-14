using WhereIsIt.Domain.Models;
using WhereIsIt.Domain.Optional;

namespace WhereIsIt.Domain.EntriesProcessing;

internal abstract class RuleBasedProcessor : IEntryProcessor
{
    protected abstract IMultiwaySplitter Splitter { get; }

    public IEnumerable<Entry> Execute(IEnumerable<Line> lines) =>
        lines.Select(this.Splitter.ApplyTo).Map();
}