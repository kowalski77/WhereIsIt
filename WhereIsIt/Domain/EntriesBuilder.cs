﻿using WhereIsIt.Domain.EntriesProcessing;
using WhereIsIt.Domain.Models;

namespace WhereIsIt.Domain;

internal class EntriesBuilder
{
    private ITextReader Reader { get; set; } = TextReader.Empty;

    private IEntryProcessor Processor { get; set; } = DoNothing.Empty;

    public static EntriesBuilder New => new();

    public EntriesBuilder With(ITextReader textReader)
    {
        this.Reader = textReader;
        return this;
    }

    public EntriesBuilder Use(IEntryProcessor processor)
    {
        this.Processor = this.Processor.Append(processor);
        return this;
    }

    public EntriesCollection Build() => this.Processor.Execute(this.Reader.Read()).ToCollection();
}
