using Xunit;
using Xunit.Abstractions;

namespace LeetCode.BattleDev.TableauMedaille;

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
        List<string> countries = new List<string>()
        {
            "Italie 9 13 15",
            "Canada 10 9 10",
            "Ouzbekistan 10 9 7",
        };
        _output.WriteLine("Testing for input: ");

        var  value = _solution.Execute(countries,1);

        Assert.Equal("Canada",value);
    }
    

}
