using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.EntriesProcessing;

internal interface IMultiwaySplitter
{
    // TODO: maybe
    Entry? ApplyTo(Line line);
}
