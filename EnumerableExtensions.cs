using System;
using System.Collections.Generic;

namespace VSIX_CCA_ProjectTemplate
{

    public static class EnumerableExtensions
    {
       
        public static IEnumerable<TSource> Recursive<TSource>(this IEnumerable<TSource> children, Func<TSource, IEnumerable<TSource>> childDelegate)
        {
            return Recursive(children, childDelegate, source => true);
        }

    
        public static IEnumerable<TSource> Recursive<TSource>(this IEnumerable<TSource> children, Func<TSource, IEnumerable<TSource>> childDelegate, Func<TSource, bool> predicate)
        {
            foreach (var source in children)
            {
                var grandchildren = childDelegate(source);
                foreach (var grandchild in Recursive(grandchildren, childDelegate, predicate))
                    yield return grandchild;
                if (predicate(source))
                    yield return source;
            }
        }


        public static Dictionary<TKey, TValue> AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);

            return dictionary;
        }
    }
}