using Xunit;
using Xunit.Abstractions;

namespace LeetCode.ArraysAndHashing.TwoSum;

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
    [InlineData(new int[] {2, 7, 11, 15},9,new int[] {0,1})]
    [InlineData(new int[] {3,2,4},6,new int[] {1,2})]
    public void Return_Index_For_Sum_When_Equal_To_Target( int[] nums,int target,int[] result)
    {

        Tuple<int, int> answer = Tuple.Create(result[0], result[1]);
        
        _output.WriteLine("Testing for input: [2, 7, 11, 15]");

        var  value = _solution.Execute(nums,target,1);
        _output.WriteLine(value.ToString());

        Assert.Equal(answer,value);
    }
    

}
