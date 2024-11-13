using DefaultNamespace;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeetCode.ArraysAndHashing.MergeSortedArray;

public class Solution : ISolution
{
    private ITestOutputHelper _output;
    public Solution(ITestOutputHelper output)
    {
        _output = output;
    }

    public  int[] Execute(int[] a1,int[] a2,int typeSolution)
    {
        switch (typeSolution)
        {
            case 1:
                return MergeSortedArray(a1,a2);
            default:
                return MergeSortedArray(a1,a2);

        }
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = m - 1; 
        int j = n - 1; 
        int k = m + n - 1;

        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[k--] = nums1[i--];
            }
            else
            {
                nums1[k--] = nums2[j--];
            }
        }

        while (j >= 0)
        {
            nums1[k--] = nums2[j--];
        }
    }

    
    public int[] MergeSortedArray(int[] nums1,int[] nums2)
    {
        int leftN = 0;
        int leftM = 0;
        _output.WriteLine(nums2.Length.ToString());
        _output.WriteLine("nums2.Length");
        if (nums1.Length == 0)
        {
            return nums2;
        }
        if (nums2.Length == 0)
        {
            _output.WriteLine("ici .Length");

            return nums1;
        }

        int[] result = new int[nums1.Length];

        
        for (int j = 0; j < nums1.Length ; j++)
        {
            
            
            if(nums2[leftM] 
               < nums1[leftN] || nums1[leftN] == 0 )
            {
                result[leftN+leftM] = nums2[leftM];
                leftM++;
            }else if (nums1[leftN] <= nums2[leftM])
            {
                result[leftN+leftM]= nums1[leftN];
                leftN++;
            }


        }

        return result;


    }
}