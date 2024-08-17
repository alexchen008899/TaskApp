using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace NYU.Windows.Helpers;

public static class ObservableCollectionExtensions
{
    public static void ReplaceOrAdd<T>(this ObservableCollection<T> collection,
        T item,
        Func<T, bool> predicate)
    {
        var existingItem = collection.FirstOrDefault(predicate);

        if (existingItem is not null)
        {
            var index = collection.IndexOf(existingItem);
            collection[index] = item;
        }
        else
        {
            collection.Add(item);
        }
    }
}
