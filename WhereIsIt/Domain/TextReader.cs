using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain;

internal class TextReader : ITextReader
{
    public static ITextReader Empty { get; } = new TextReader();

    public IReadOnlyList<Line> Read() => Enumerable.Empty<Line>().ToList();
}
