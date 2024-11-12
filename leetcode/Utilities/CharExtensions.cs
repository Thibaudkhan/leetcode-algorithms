namespace DefaultNamespace;

public static class CharExtensions
{
    public static bool IsAlphaNumerical(this char c)
    {
        return (c >= 'a' && c <= 'z') ||
               (c >= 'A' && c <= 'Z') ||
               (c >= '0' && c <= '9');
    }
}
