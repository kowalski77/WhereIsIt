namespace WhereIsIt.Domain.EntriesProcessing;

internal sealed class SemicolonProcessor : SplitProcessor
{
    protected override Func<char> Separator => () => ';';
}
