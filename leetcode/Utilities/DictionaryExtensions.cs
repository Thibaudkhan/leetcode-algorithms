namespace DefaultNamespace;

public static class DictionaryExtensions
{
    public static string ToFormattedString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
    {
        return "{" + string.Join(", ", dictionary.Select(kvp => $"{kvp.Key}: {kvp.Value}")) + "}";
    }
}
