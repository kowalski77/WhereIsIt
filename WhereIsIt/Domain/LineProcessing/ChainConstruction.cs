namespace WhereIsIt.Domain.LineProcessing;

// decorator pattern
internal static class ChainConstruction
{
    public static ILineProcessor Then(
        this ILineProcessor first, ILineProcessor next) =>
        first is DoNothing ? next
        : next is DoNothing ? first
        : new ChainedProcessor(first, next);
}