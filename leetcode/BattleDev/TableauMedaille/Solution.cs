using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using DefaultNamespace;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeetCode.BattleDev.TableauMedaille;

public class Country
{
    public string Name { get; set; }
    public int Gold { get; set; }
    public int Silver { get; set; }
    public int Bronze { get; set; }

    // Constructeur
    public Country(string name, int gold, int silver, int bronze)
    {
        Name = name;
        Gold = gold;
        Silver = silver;
        Bronze = bronze;
    }
}

public class Solution : ISolution
{
    private readonly ITestOutputHelper _output;

    public Solution(ITestOutputHelper output)
    {
        _output = output;
    }

    public string Execute(List<string> countries,int typeSolution)
    {
        // Stopwatch stopWatch = new();
        // stopWatch.Start();
        // GetMostMedalCountryWithCountry(countries);
        //
        // stopWatch.Stop();
        // TimeSpan ts = stopWatch.Elapsed;
        // _output.WriteLine("Linq: " +
        //                   String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
        //
        // stopWatch.Restart();
        // GetMostMedalCountry(countries);
        // stopWatch.Stop();
        // ts = stopWatch.Elapsed;
        // _output.WriteLine(" No linq: " +
        //                   String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10) +
        //                   " - " );
        switch (typeSolution)
        {
            case 1:
                return GetMostMedalCountry(countries);
            case 2:
                return GetMostMedalCountryWithCountry(countries);
            default:
                return GetMostMedalCountry(countries);

        }
    }

    private string GetMostMedalCountryWithCountry(List<string> lines)
    {

        List<Country> countries = new List<Country>();
        foreach (var line in lines)
        {
            string[] parts = line.Split(' ');
            countries.Add(new Country(
                parts[0],
                int.Parse(parts[1]),
                int.Parse(parts[2]),
                int.Parse(parts[3])
            ));
        }
        
        Country topCountry = countries
            .OrderByDescending(c => c.Gold)
            .ThenByDescending(c => c.Silver)
            .ThenByDescending(c => c.Bronze)
            .First();

        return topCountry.Name;
    }

    
    private string GetMostMedalCountry(List<string> countries)
    { 
        int pastMaxGoldMedal = 0;
        int pastGoldMaxSilverMedal = 0;
        int pastGoldMaxBronzeMedal = 0;
        string  maxCountry = "";
       foreach(string country in countries)
       {
           string[] tab = country.Split(" ");
           int goldMedal = Int32.Parse(tab[1]);
           int actualSilverMedal = Int32.Parse(tab[2]);
           int bronzeMedal = Int32.Parse(tab[3]);


           if (goldMedal > pastMaxGoldMedal ||
               (goldMedal == pastMaxGoldMedal && actualSilverMedal > pastGoldMaxSilverMedal) ||
               (goldMedal == pastMaxGoldMedal && actualSilverMedal == pastGoldMaxSilverMedal && bronzeMedal > pastGoldMaxBronzeMedal))
           {
               pastMaxGoldMedal = goldMedal;
               pastGoldMaxSilverMedal = actualSilverMedal;
               pastGoldMaxBronzeMedal = bronzeMedal;
               maxCountry = tab[0];
           }



       }

       return maxCountry;
    }




}