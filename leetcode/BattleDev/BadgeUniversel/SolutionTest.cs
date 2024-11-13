using Xunit;
using Xunit.Abstractions;

namespace LeetCode.BattleDev.BadgeUniversel;

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
    public void Return_Good_Badge( )
    {
        string[] n=  {"4","42","4245555555555555"};
        
        _output.WriteLine("Testing for input: ");

        var  value = _solution.Execute(n,1);

        Assert.Equal("4245555555555555",value);
    }
    

}
