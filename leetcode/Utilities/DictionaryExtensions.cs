using System.Collections;

namespace DefaultNamespace;

public static class DictionaryExtensions
{
    public static string ToFormattedString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
    {
        return "{" + string.Join(", ", dictionary.Select(kvp => $"{FormatObject(kvp.Key)}: {FormatObject(kvp.Value)}")) + "}";
    }


    private static string FormatObject(object obj)
    {
        // Si l'objet est un dictionnaire générique
        if (obj is IDictionary dictionary)
        {
            var entries = new List<string>();
            foreach (var key in dictionary.Keys)
            {
                var value = dictionary[key];
                entries.Add($"{FormatObject(key)}: {FormatObject(value)}");
            }
            return "{" + string.Join(", ", entries) + "}";
        }
        // Si l'objet est un IEnumerable mais pas une chaîne
        else if (obj is IEnumerable enumerable && !(obj is string))
        {
            return "[" + string.Join(", ", enumerable.Cast<object>().Select(FormatObject)) + "]";
        }
        // Sinon, renvoie l'objet sous forme de chaîne
        return obj?.ToString() ?? "null";
    }
}