using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.LineProcessing;

internal class DoNothing : ILineProcessor
{
    public IEnumerable<Line> Execute(IEnumerable<Line> lines) =>
        lines;
}
