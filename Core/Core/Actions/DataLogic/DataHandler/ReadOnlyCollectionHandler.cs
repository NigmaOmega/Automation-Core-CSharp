using System.Collections.Generic;


public static class ReadOnlyCollectionHandler
{
    public static List<T> ToList<T>(this IReadOnlyCollection<T> collections)
    {
        return new List<T>(collections);
    }
}

