using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using DefaultNamespace;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeetCode.BattleDev.KayakCross;


public class Node
{
    public string Direction;
    public Node Next { get; set; }
    
    
    public Node(string direction)
    {
        Direction = direction;
        Next = null;
    }
}

public class Solution : ISolution
{
    private readonly ITestOutputHelper _output;
    private List<Node> nodes;
    public Solution(ITestOutputHelper output)
    {
        _output = output;
    }

    public string Execute( string[,] matrice,int typeSolution)
    {
      
        switch (typeSolution)
        {
            case 1:
                return GettingFirstPosition(matrice);

            default:
                return GettingFirstPosition(matrice);

        }
    }

  
    
    private string GettingFirstPosition( string[,] matrice)
    { 
        
        
      return "";
    }

    private void InitiNode(int x,int y,string[,]  matrice)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                //Node node = new Node()
            }
        }
    }




}