using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using DefaultNamespace;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeetCode.TwoPointers.IsPalindrome;

public class Solution : ISolution
{
    private readonly ITestOutputHelper _output;

    public Solution(ITestOutputHelper output)
    {
        _output = output;
    }

    public bool Execute(string str,int typeSolution)
    {
        switch (typeSolution)
        {
            case 1:
                return IsPalidrome(str);
            default:
                return IsPalidrome(str);

        }
    }

    private bool IsPalidrome(string str)
    {
        str = str.ToLowerInvariant();
        str = Regex.Replace(str, "[^a-z0-9]", "");

        int left = 0;
        int right = str.Length - 1;
        
        if (right < left)
        {
            return true;
        }

        while (left <= right && str[left] == str[right])
        {
            left++;
            right--;
        }

        return ((str.Length ) % 2 != 0 && left >= right ) || ((str.Length )  % 2 == 0 && left >= right ) ;
    }
    
    


  
   
}