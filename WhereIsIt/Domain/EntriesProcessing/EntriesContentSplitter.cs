using WhereIsIt.Domain.Models;
using WhereIsIt.Domain.Optional;

namespace WhereIsIt.Domain.EntriesProcessing;

internal class EntriesContentSplitter : RuleBasedProcessor
{
    protected override IMultiwaySplitter Splitter =>
        CharacterSplitter.SemicolonSplitter
        .Append(CharacterSplitter.CommaSplitter);
}

internal class CharacterSplitter : IMultiwaySplitter
{
    private char Character { get; }

    private CharacterSplitter(char character) => this.Character = character;

    public Maybe<Entry> ApplyTo(Line line)
    {
        var parts = line.Value.Split(this.Character);
        if (parts.Length < 2)
        {
            return None.Value;
        }

        return Entry.New(parts[0], parts[1], parts[2]);
    }

    public static IMultiwaySplitter SemicolonSplitter => new CharacterSplitter(';');

    public static IMultiwaySplitter CommaSplitter => new CharacterSplitter(',');
}
