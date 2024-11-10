using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using DefaultNamespace;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeetCode.ArraysAndHashing.ValidAnagram;

public class Solution : ISolution
{
    private readonly ITestOutputHelper _output;

    public Solution(ITestOutputHelper output)
    {
        _output = output;
    }

    public bool Execute(string s,string t,int typeSolution)
    {
        switch (typeSolution)
        {
            case 1:
                return CheckIfAnagramCreatingTwoDico(s,t);
            case 2:
                return CheckIfAnagramWithArray2(s,t);
            case 3:
                return CheckIfAnagramWith26Char(s,t);
            default:
                return CheckIfAnagramCreatingTwoDico(s,t);

        }
    }

    private bool CheckIfAnagramWith26Char(string s, string t)
    {
        if(s.Length!=t.Length) return false;
        int[] CharNum = new int[26];
        foreach (var c in s) CharNum[c - 'a']++;
        foreach (var c in t) CharNum[c - 'a']--;
        
        foreach(int n in  CharNum){
            if(n>0){
                return false;
            }
        }
        return true;
    }


    private bool CheckIfAnagramWithArray2(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }


        var sArray = s.ToArray();
        var tArray = t.ToArray();
        
        Array.Sort(sArray);
        Array.Sort(tArray);

        return new string(sArray) == new string(tArray);

    }
    
    private bool CheckIfAnagramWithArray(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        string sortedS = new string(s.OrderBy(c => c).ToArray());
        string sortedT = new string(t.OrderBy(c => c).ToArray());

        _output.WriteLine(sortedS);
        _output.WriteLine(sortedT);

        
        return sortedS == sortedT;

    }
    
    
    
    private bool CheckIfAnagramCreatingTwoDico(string s, string t)
    {
        
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> s1 = BuildDico(s);
        Dictionary<char, int> t1 = BuildDico(t);
        
        _output.WriteLine(s1.ToFormattedString());
        _output.WriteLine(t1.ToFormattedString());
        foreach (char letter in s1.Keys) {
            if (!t1.ContainsKey(letter)
                || s1[letter] != t1[letter]) {
                return false;
            }
        }
        return true;
    }    
    
    private bool CheckIfAnagramCreatingTwoDico1(string s, string t)
    {
        
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> s1 = BuildDico(s);
        Dictionary<char, int> t1 = BuildDico(t);
        
        _output.WriteLine(s1.ToFormattedString());
        _output.WriteLine(t1.ToFormattedString());
        return  s1.OrderBy(kvp => kvp.Key).SequenceEqual(t1.OrderBy(kvp => kvp.Key));
    }

    private Dictionary<char, int> BuildDico(string word)
    {
        Dictionary<char, int> anagram = new Dictionary<char, int>();
        for (int i = 0; i < word.Length; i++)
        {
            if(anagram.ContainsKey(word[i]))
            {
                anagram[word[i]]++;
            }
            else
            {
                anagram[word[i]] = 0;
            }
        }

        return anagram;
    }
    
   
}