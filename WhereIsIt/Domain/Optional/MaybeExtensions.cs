using Arch.SharedKernel;

namespace WhereIsIt.Domain.Optional;

public static class MaybeExtensions
{
    // Select
    public static Maybe<TResult> Map<T, TResult>(this Maybe<T> obj, Func<T, TResult> map) =>
        obj is Some<T> some ? new Some<TResult>(map.NonNull()(some.Content)) : new None<TResult>();

    public static IEnumerable<T> Map<T>(this IEnumerable<Maybe<T>> obj) =>
        obj.NonNull().Where(x => x is Some<T>).Select(x => ((Some<T>)x).NonNull().Content);

    // Where
    public static Maybe<T> Filter<T>(this Maybe<T> obj, Func<T, bool> predicate) =>
        obj is Some<T> some && !predicate.NonNull()(some.Content) ? new None<T>() : obj;

    // Single or default
    public static T Reduce<T>(this Maybe<T> obj, T substitute) =>
        obj is Some<T> some ? some.Content : substitute.NonNull();

    public static T Reduce<T>(this Maybe<T> obj, Func<T> substitute) =>
        obj is Some<T> some ? some.Content : substitute.NonNull()();

    // Match (switch) 
    public static TR Match<T, TR>(this Maybe<T> obj, Func<T, TR> some, Func<TR> none) =>
        obj is Some<T> someObj ? some.NonNull()(someObj.Content) : none.NonNull()();

    public static async Task<TR> Match<T, TR>(this Maybe<T> obj, Func<T, Task<TR>> some, Func<TR> none) =>
        obj is Some<T> someObj ?
        await some.NonNull()(someObj.Content).ConfigureAwait(false) :
        none.NonNull()();

    // Or
    public static Maybe<T> OrElse<T>(this Maybe<T> maybe, Func<Maybe<T>> next) =>
        maybe is Some<T> some ? some : next.NonNull()();
}