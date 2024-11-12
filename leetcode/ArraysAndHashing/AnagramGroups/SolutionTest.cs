using Xunit;
using Xunit.Abstractions;
using DefaultNamespace;

namespace LeetCode.ArraysAndHashing.AnagramGroups;

public class SolutionTest
{
    private Solution _solution;
    private readonly ITestOutputHelper _output;

    public SolutionTest(ITestOutputHelper output)
    {
        _output = output;

        _solution = new Solution(output);
    }
    
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Return_InTo_SubList_Anagram(string[] strs, List<List<string>> expected)
    {
        

        var res = _solution.Execute(strs,1);
        //_output.WriteLine(res.ToFormattedString());
        PrintListOfLists(res);
        _output.WriteLine("res.ToString()");

        Assert.True(AreEqualIgnoringOrder(expected,res));
    }
    
    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[]
        {
            new string[] {"act", "pots", "tops", "cat", "stop", "hat"},
            new List<List<string>>
            {
                new List<string> { "hat" },
                new List<string> { "act", "cat" },
                new List<string> { "stop", "pots", "tops" }
            }
        };
        yield return new object[]
        {
            new string[] {"bdddddddddddd","bdd", "bbbbbbbbbbbbc"},
            new List<List<string>>
            {
                new List<string> { "bbbbbbbbbbbbc" },
                new List<string> { "bdddddddddddd"},
                new List<string> { "bdd"}
            }
        };

        yield return new object[]
        {
            new string[] {"x"},
            new List<List<string>>
            {
                new List<string> { "x" }
            }
        };
        yield return new object[]
        {
            new string[] {""},
            new List<List<string>>
            {
                new List<string> { "" }
            }
        };
    }
    
    private static bool AreEqualIgnoringOrder(List<List<string>> list1, List<List<string>> list2)
    {
        // Si les tailles sont différentes, les listes ne sont pas égales
        if (list1.Count != list2.Count)
            return false;

        // Trier chaque sous-liste et la liste principale
        var sortedList1 = list1
            .Select(subList => subList.OrderBy(x => x).ToList())
            .OrderBy(subList => string.Join(",", subList))
            .ToList();

        var sortedList2 = list2
            .Select(subList => subList.OrderBy(x => x).ToList())
            .OrderBy(subList => string.Join(",", subList))
            .ToList();

        // Comparer chaque sous-liste
        for (int i = 0; i < sortedList1.Count; i++)
        {
            if (!sortedList1[i].SequenceEqual(sortedList2[i]))
                return false;
        }

        return true;
    }
    
    public void PrintListOfLists(List<List<string>> listOfLists)
    {
        for (int i = 0; i < listOfLists.Count; i++)
        {
            _output.WriteLine($"List {i}: [{string.Join(", ", listOfLists[i])}]");
        }
    }

}
