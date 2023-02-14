using WhereIsIt.Domain.Models;
using WhereIsIt.Domain.Optional;

namespace WhereIsIt.Domain.EntriesProcessing;

internal class LongLineEntries : RuleBasedProcessor
{
    protected override IMultiwaySplitter Splitter => new LongLineSplitter();
}

internal class LongLineSplitter : IMultiwaySplitter
{
    public Maybe<Entry> ApplyTo(Line line)
    {
        static bool IsLong(Line line) => line.Value.Length > 50;

        if (IsLong(line))
        {
            var parts = SplitLine(line);
            return Entry.New(parts![0], parts[1], parts[2]);
        }

        return None.Value;
    }

    private static string[] SplitLine(Line line)
    {
        var length = line.Value.Length;
        var partLength = length / 3;
        var remainder = length % 3;

        ReadOnlySpan<char> span = line.Value.AsSpan();

        var parts = new string[3];
        for (int i = 0, startIndex = 0; i < 3; i++)
        {
            length = partLength + (i < remainder ? 1 : 0);
            parts[i] = span.Slice(startIndex, length).ToString();
            startIndex += length;
        }

        return parts;
    }
}
