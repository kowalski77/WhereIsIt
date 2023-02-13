using WhereIsIt.Domain.LineProcessing;
using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain;

internal class EntriesBuilder
{
    private ITextReader Reader { get; set; } = TextReader.Empty;

    private ILineProcessor LineProcessor { get; set; } = new DoNothing();
        
    public static EntriesBuilder New => new();

    public EntriesBuilder With(ITextReader textReader)
    {
        this.Reader = textReader;
        return this;
    }

    public EntriesBuilder Use(ILineProcessor textProcessor)
    {
        return this;
    }

    public IReadOnlyList<Entry> Build()
    {
        foreach(Line line in this.Reader.Read())
        {

        }

        //return this.TextProcessor.Execute(this.Reader.Read()).ToList();
        return null;
    }
}
