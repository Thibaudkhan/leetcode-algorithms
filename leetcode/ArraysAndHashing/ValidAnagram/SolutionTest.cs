using Xunit;
using Xunit.Abstractions;

namespace LeetCode.ArraysAndHashing.ValidAnagram;

public class SolutionTest
{
    private Solution _solution;
    private readonly ITestOutputHelper _output;


    public SolutionTest(ITestOutputHelper output)
    {
        _output = output;

        _solution = new Solution(_output);
    }
    
    [Fact]
    public void If_Valid_Anagram_Return_True()
    {
        string s = "anagram", t = "nagaram";
        _output.WriteLine("Testing for input: [1, 2, 3, 1]");

        bool isValid = _solution.Execute(s,t,3);
        
        Assert.True(isValid);
    }
    [Fact]
    public void If_Not_Valid_Anagram_Return_False()
    {
        string s = "rat", t = "car";

        bool isValid = _solution.Execute(s,t,3);
        
        Assert.False(isValid);
    }
}
