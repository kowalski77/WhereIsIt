using WhereIsIt;
using WhereIsIt.Domain;
using WhereIsIt.Domain.EntriesProcessing;
using WhereIsIt.Domain.Models;
using WhereIsIt.Infrastructure.Files;
using WhereIsIt.Infrastructure.Sql;

Console.WriteLine("Where is it?");

if (Support.Verify(args))
{
    Console.WriteLine("Lets start");
    await ProcessAsync(new FileInfo(args[0]));
}

static async Task ProcessAsync(FileInfo fileInfo)
{
    EntriesCollection entries =
        EntriesBuilder.New
        .With(new LineFileReader(fileInfo))
        .Use(new EntriesContent())
        .Build();

    WhereIsItContext context = new();

    IEntryStore entryStore = new SqlEntryStore(context);
    entryStore.RemoveAll();
    entryStore.Save(entries);

    await context.SaveChangesAsync();
}