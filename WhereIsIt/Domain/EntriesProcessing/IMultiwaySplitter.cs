using WhereIsIt.Domain.Models;
using WhereIsIt.Domain.Optional;

namespace WhereIsIt.Domain.EntriesProcessing;

internal interface IMultiwaySplitter
{
    Maybe<Entry> ApplyTo(Line line);
}
