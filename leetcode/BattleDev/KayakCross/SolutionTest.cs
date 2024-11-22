using Xunit;
using Xunit.Abstractions;

namespace LeetCode.BattleDev.KayakCross;

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
        string[,] matrix = new string[,]
        {
            { "v", "v", "v", "v" },
            { "v", "<", "v", "v" },
            { "v", ">", "v", "^" },
            { ">", "^", "v", "<" },
            { "v", ">", "v", "<" },
            { ">", "v", "<", "^" },
            { ">", "v", "v", "<" },
            { ">", ">", "v", "<" }
        };
      
        _output.WriteLine("Testing for input: ");

        var  value = _solution.Execute(matrix,1);

        Assert.Equal("1",value);
    }
    

}
