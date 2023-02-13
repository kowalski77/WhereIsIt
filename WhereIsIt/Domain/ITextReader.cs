using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain;

internal interface ITextReader
{
    IReadOnlyList<Line> Read();
}
