using System.Diagnostics;

namespace leetcode.TestingThings;

public class User{
    public int Id { get; set; }
    public string Name { get; set; }
}

public static class UnderstandingYield
{

  public static void Start()
    {
        Stopwatch stopWatch = new();
        stopWatch.Start();

        // Création de la liste de 20 000 000 utilisateurs
        List<User> users = new();
        for (int i = 0; i < 10_000_000; i++)
        {
            users.Add(new User { Id = 0, Name = i % 3 == 0 ? "test" + i : "hello" + i });
        }

        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        Console.WriteLine("Time to build the array: " +
                          String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));

        // // Test avec LINQ Count
        // stopWatch.Restart();
        // int countLinqCount = GetByLinqCount(users, "test");
        // stopWatch.Stop();
        // ts = stopWatch.Elapsed;
        // Console.WriteLine("Time to build the array using LINQ Count: " +
        //                   String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10) +
        //                   " - " + countLinqCount);
        //
        // // Test avec boucle `for`
        // stopWatch.Restart();
        // int countFor = GetByFor(users, "test");
        // stopWatch.Stop();
        // ts = stopWatch.Elapsed;
        // Console.WriteLine("Time to build the array using For: " +
        //                   String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10) +
        //                   " - " + countFor);
        //
        // // Test avec LINQ Where
        // stopWatch.Restart();
        // int countLinqWhere = GetByLinqWhere(users, "test");
        // stopWatch.Stop();
        // ts = stopWatch.Elapsed;
        // Console.WriteLine("Time to build the array using LINQ Where: " +
        //                   String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10) +
        //                   " - " + countLinqWhere);
        //
        // // Test avec LINQ Where 2
        // stopWatch.Restart();
        // int countLinqWhere2 = GetByLinqWhere2(users, "test");
        // stopWatch.Stop();
        // ts = stopWatch.Elapsed;
        // Console.WriteLine("Time to build the array using LINQ Where: " +
        //                   String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10) +
        //                   " - " + countLinqWhere2);
        //
        
        // Test Create
        stopWatch.Restart();
        var usersR = Create(users);
        stopWatch.Stop();
        ts = stopWatch.Elapsed;
        Console.WriteLine("Time to add for : " +
                          String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10) +
                          " - " + usersR);
        
        // Test Create linq

        stopWatch.Restart();
        var usersR2 = Create2(users);
        stopWatch.Stop();
        ts = stopWatch.Elapsed;
        Console.WriteLine("Time to add  1 " +
                          String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10) +
                          " - " + usersR2);
        
        // Test Create linq 2

        stopWatch.Restart();
        var usersR3 = Create3(users);
        stopWatch.Stop();
        ts = stopWatch.Elapsed;
        Console.WriteLine("Time to add 2: " +
                          String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10) +
                          " - " + usersR3);
    }

    private static int GetByLinqCount(List<User> users, string value) =>
        users.Count(x => x.Name.Contains(value));

    private static int GetByLinqWhere(List<User> users, string value) =>
        users.Where(x => x.Name.Contains(value)).Count();
    
    private static int GetByLinqWhere2(List<User> users, string value) =>
        users.Where(x => x.Name.Contains(value)).ToList().Count;

    private static List<User> Create2(List<User> users) =>
        users.Where(x => x.Name.Contains("test")).ToList();
    
    private static List<User> Create3(List<User> users) =>
        users.Where(x => x.Name == "test").ToList();

    private static int GetByFor(List<User> users, string value)
    {
        int count = 0;
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Name.Contains(value))
                count++;
        }
        return count;
    }

    private static List<User> Create(List<User> users)
    {
        var results = new List<User>();

        for (int i = 0; i < 10_000_000; i++)
        {
            if (users[i].Name == "test")
            {
                results.Add(users[i]);
            }
        }
        
        return results;
    }

    
    
    
    
    public static void TestingYield()
    {
        var numbers = Enumerable.Range(1, 20_000_000).ToList();

        //var evenNumbersLazy = numbers.Where(n => n % 2 == 0);

        
        
        
        var sw = new Stopwatch();

        // sw.Start();
        // foreach (var num in evenNumbersLazy) { }
        // sw.Stop();
        // Console.WriteLine($"Lazy: {sw.ElapsedMilliseconds} ms");


        sw.Restart();
        var evenNumbersFor = new List<int>();
        
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] >1 )
                evenNumbersFor.Add(numbers[i]);
        }
        sw.Stop();  
        Console.WriteLine($"For loop: {sw.ElapsedMilliseconds} ms");

        
        sw.Restart();
        var evenNumbersImmediate = numbers.Where(n => n > 1).ToList();

        foreach (var num in evenNumbersImmediate) { }
        sw.Stop();
        Console.WriteLine($"Immediate: {sw.ElapsedMilliseconds} ms");

    }
   
}