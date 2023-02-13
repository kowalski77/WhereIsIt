namespace WhereIsIt.Domain.Models;

internal record Entry(Guid Id, string Tag, string Description, string Location)
{
    internal static Entry New(string tag, string description, string location) => new(Guid.NewGuid(), tag, description, location);
}