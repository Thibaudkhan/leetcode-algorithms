using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DefaultNamespace;

public static class StringExtensions
{
    public static bool IsAlphaNumerical(this string str)
    {
        Regex r = new Regex("^[a-zA-Z0-9]*$");

        return r.IsMatch(str);
    }
}