namespace WhereIsIt.Domain.EntriesProcessing
{
    internal class ComaProcessor : SplitProcessor
    {
        protected override Func<char> Separator => () => ',';
    }
}
