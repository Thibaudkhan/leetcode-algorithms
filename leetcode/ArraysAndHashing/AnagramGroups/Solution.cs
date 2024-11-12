using DefaultNamespace;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeetCode.ArraysAndHashing.AnagramGroups;

public class Solution : ISolution
{
    private readonly ITestOutputHelper _output;

    public Solution(ITestOutputHelper output)
    {
        _output = output;
    }
    
    public  List<List<string>> Execute(string[] strs,int typeSolution)
    {
        switch (typeSolution)
        {
            case 1:
                return ReturnSubStringAnagram(strs);
            case 2:
                return ReturnSubStringAnagramBetter(strs);

            default:
                return ReturnSubStringAnagram(strs);

        }
    }

    public List<List<string>> ReturnSubStringAnagramBetter(string[] strs)
    {
        var dict = new Dictionary<string, List<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            var str = strs[i];
            var charArray = new char[26];

            for (int j = 0; j < str.Length; j++)
            {
                charArray[str[j] - 'a']++;
            }
            
            var key = new string(charArray);
            _output.WriteLine("key");
            _output.WriteLine(key);

            if (!dict.ContainsKey(key))
            {
                dict[key] = new List<string>();
            }

            dict[key].Add(str);
        }

        return dict.Values.ToList();
    }

    
    public  List<List<string>> ReturnSubStringAnagram(string[] strs )
    {

        Dictionary<string, List<string>> dico = new Dictionary<string, List<string>>();

        List<List<string>> response = new List<List<string>>();
        foreach (var str in strs)
        {
            int[] charNum = new int[26];

            for (int j = 0; j < str.Length; j++)
            {
                charNum[str[j] - 'a']++;
            }

            string key = string.Join("-", charNum);


            _output.WriteLine(dico.ToFormattedString());

            if (!dico.TryAdd(key, new List<string> { str }))
            {
                dico[key].Add(str);

            }


        }

        return dico.Values.ToList();

        
       

    }
    
    
    private void PrintListOfLists(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            _output.WriteLine($"List {i}: {list[i]}");
        }
    }
    public static string FormatArray(int[] array)
    {
        return "[" + string.Join(", ", array) + "]";
    }


}