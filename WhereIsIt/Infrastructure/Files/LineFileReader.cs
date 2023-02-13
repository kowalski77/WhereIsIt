using WhereIsIt.Domain;
using WhereIsIt.Domain.Models;

namespace WhereIsIt.Infrastructure.Files;

internal class LineFileReader : ITextReader
{
    private FileInfo Source { get; }

    public LineFileReader(FileInfo source) => Source = source;

    public IReadOnlyList<Line> Read() => ParseSource().ToList();

    private IEnumerable<Line> ParseSource()
    {
        using StreamReader reader = new(Source.FullName);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            yield return new Line(line!);
        }
    }
}
