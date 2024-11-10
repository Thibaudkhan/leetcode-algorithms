using Xunit;

namespace LeetCode.ArraysAndHashing.DuplicateInteger;

public class SolutionTest
{
    private Solution _solution;

    public SolutionTest()
    {
        _solution = new Solution();
    }
    
    [Fact]
    public void If_Duplicate_Value_Return_True()
    {
        int[] nums = { 1, 2, 3, 3 };

        bool isDuplicate = _solution.Execute(nums,1);
        
        Assert.True(isDuplicate);
    }
    [Fact]
    public void If_Not_Duplicate_Value_Return_False()
    {
        int[] nums = { 1, 2, 3 };

        bool isDuplicate = _solution.Execute(nums,1);

        Assert.False(isDuplicate);
    }
}
