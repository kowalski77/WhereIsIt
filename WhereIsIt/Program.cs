using WhereIsIt;
using WhereIsIt.Domain;
using WhereIsIt.Domain.EntriesProcessing;
using WhereIsIt.Domain.Models;
using WhereIsIt.Infrastructure.Files;

Console.WriteLine("Where is it?");

if (Support.Verify(args))
{
    Console.WriteLine("Lets start");
    Process(new FileInfo(args[0]));
}

static void Process(FileInfo fileInfo)
{
    IReadOnlyList<Entry?> entries = 
        EntriesBuilder.New
        .With(new LineFileReader(fileInfo))
        .Use(new EntriesContentSplitter())
        .Build();


}


        //.Use(new SemicolonProcessor())
        //.Use(new ComaProcessor())