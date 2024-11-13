using Xunit;
using Xunit.Abstractions;

namespace LeetCode.ArraysAndHashing.MergeSortedArray;

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
    [InlineData(new int[] { 1, 2, 3, 0, 0, 0 }, new int[] { 2, 5, 6 }, new int[] { 1, 2, 2, 3, 5, 6 })]
    [InlineData(new int[] { 1}, new int[] {}, new int[] { 1 })]
    [InlineData(new int[] { 0}, new int[] {1}, new int[] { 1 })]
    public void If_Not_Duplicate_Value_Return_False(int[] nums, int[] numsB, int[] expected)
    {

        int[] res = _solution.Execute(nums,numsB,1);
        _output.WriteLine("res.ToString()");
        _output.WriteLine(string.Join(" ", res));

        Assert.Equal(expected,res);
    }
}
