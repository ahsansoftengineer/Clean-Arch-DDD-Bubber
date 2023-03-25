### API 
#### Aggregate
```csharp
public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func);
public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func);
public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector);
```

#### Min, Max, Count, Sum, Average
```charp
public static int Min(this IEnumerable<int, double, float, etc...> source)
public static TSource? Min<TSource>(this IEnumerable<TSource> source) => Min(source, comparer: null); // For Complex Types
public static TSource? Min<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer); // For Complex Types
```,

#### Where
```csharp
public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
private static IEnumerable<TSource> WhereIterator<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)

// Figure out what is the purpose of them
private sealed partial class WhereEnumerableIterator<TSource>
internal sealed partial class WhereArrayIterator<TSource>
private sealed partial class WhereListIterator<TSource>
private sealed partial class WhereSelectArrayIterator<TSource, TResult>
```

#### 