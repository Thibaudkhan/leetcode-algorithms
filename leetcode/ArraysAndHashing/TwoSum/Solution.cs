using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using DefaultNamespace;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeetCode.ArraysAndHashing.TwoSum;

public class Solution : ISolution
{
    private readonly ITestOutputHelper _output;

    public Solution(ITestOutputHelper output)
    {
        _output = output;
    }

    public Tuple<int, int> Execute(int[] nums,int target,int typeSolution)
    {
        switch (typeSolution)
        {
            case 1:
                return ReturnIndicesOfTwoSumsDico(nums,target);
            default:
                return ReturnIndicesOfTwoSumsDico(nums,target);

        }
    }

    private Tuple<int, int> ReturnIndicesOfTwoSumsDico(int[] nums,int target)
    {

        Dictionary<int, int> dico = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length;i++)        
        {

            if (dico.ContainsKey(target - nums[i]))
            {
                return Tuple.Create(dico[target - nums[i]],i );
            }
            dico[nums[i]] = i;

        }
       return Tuple.Create(0,0);
    }


  
   
}