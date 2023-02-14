using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.EntriesProcessing;

internal interface IEntryProcessor
{
    IEnumerable<Entry?> Execute(IEnumerable<Line> lines);
}
