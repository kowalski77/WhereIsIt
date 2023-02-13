using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain.LineProcessing;

// decorator pattern
internal class ChainedProcessor : ILineProcessor
{
    private ILineProcessor Inner { get; }

    private ILineProcessor Next { get; }

    public ChainedProcessor(ILineProcessor inner, ILineProcessor next)
    {
        Inner = inner;
        Next = next;
    }

    public IEnumerable<Line> Execute(IEnumerable<Line> lines) =>
        Next.Execute(Inner.Execute(lines));
}
