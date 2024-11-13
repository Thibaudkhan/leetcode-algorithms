using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using DefaultNamespace;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeetCode.BattleDev.BadgeUniversel;

public class Solution : ISolution
{
    private readonly ITestOutputHelper _output;

    public Solution(ITestOutputHelper output)
    {
        _output = output;
    }

    public string Execute(string[] strs,int typeSolution)
    {
        switch (typeSolution)
        {
            case 1:
                return GetGoodBadge(strs);
            default:
                return GetGoodBadge(strs);

        }
    }

    private string GetGoodBadge(string[] strs)
    {
        string res = "";
        foreach (string line in strs)
        {
            int len = line.Length;

            if (len < 3)
            {
                continue;
            }

            if ((line[0].ToString() + line[1].ToString()) != "42")
            {
                continue;
            }

            int sumA = 0;
            _output.WriteLine(len.ToString());

            for (int i = 0; i < len; i++)
            {
                if (sumA > 75)
                {
                    break;
                }

                _output.WriteLine("s");

                sumA += line[i] - '0';

            }

            _output.WriteLine(sumA.ToString());

            if (sumA != 75)
            {
                continue;
            }

            res = line;

        }

        return res;
    }




}