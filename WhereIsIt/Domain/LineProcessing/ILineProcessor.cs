using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.LineProcessing;

internal interface ILineProcessor
{
    IEnumerable<Line> Execute(IEnumerable<Line> lines);
}
