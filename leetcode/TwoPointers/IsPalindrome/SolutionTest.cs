using Xunit;
using Xunit.Abstractions;

namespace LeetCode.TwoPointers.IsPalindrome;

public class SolutionTest
{
    private Solution _solution;
    private readonly ITestOutputHelper _output;


    public SolutionTest(ITestOutputHelper output)
    {
        _output = output;

        _solution = new Solution(_output);
    }
    
    [Theory]
    [InlineData("Was it a car or a cat I saw?",true)]
    [InlineData("tab a cat", false)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    [InlineData("aa", true)]
    public void Return_Index_For_Sum_When_Equal_To_Target( string str,bool isPalindrome )
    {

        
        _output.WriteLine("Testing for input: "+str);

        var  value = _solution.Execute(str,1);

        Assert.Equal(isPalindrome,value);
    }
    

}
