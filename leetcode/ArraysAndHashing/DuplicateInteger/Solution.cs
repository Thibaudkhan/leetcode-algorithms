using DefaultNamespace;
using Xunit.Sdk;

namespace LeetCode.ArraysAndHashing.DuplicateInteger;

public class Solution : ISolution
{

    public bool Execute(int[] nums,int typeSolution)
    {
        switch (typeSolution)
        {
            case 1:
                return CheckIfDuplicate(nums);
            case 2:
                return CheckIfDuplicateWithHashSetCount(nums);
            default:
                return CheckIfDuplicate(nums);

        }
    }
    
    // Solution O(n) runtime ,O(n) stockage 
    public bool CheckIfDuplicate(int[] nums)
    {
        HashSet<int> hashSet = new HashSet<int>();
        
        foreach (int num in nums)
        {
            if (!hashSet.Add(num))
            {
                return true; 
            }
        }
        
        return false;
    }
    
    // Solution moins optimale mais plus courte 
    public bool CheckIfDuplicateWithHashSetCount(int[] nums)
    {
        return new HashSet<int>(nums).Count < nums.Length;
    }
}