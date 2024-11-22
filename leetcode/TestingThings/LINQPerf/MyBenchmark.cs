using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BenchmarkDotNet.Loggers;

namespace leetcode.TestingThings.LINQPerf;

[Config(typeof(Config))] // Utilise la configuration personnalisée

[SimpleJob(RunStrategy.Throughput, launchCount: 1, warmupCount: 5, iterationCount: 30)]
[MemoryDiagnoser]
public class MyBenchmark
{
    private List<Product> products;
    private List<int> numbersList;
    private int[] numbersArray;

    [Params(10000)] // Nombre de produits/nombres pour les benchmarks
    public int NumberOfProducts;

    private class Config : ManualConfig
    {
        public Config()
        {
            AddColumn(StatisticColumn.Median); // Ajoute la médiane
            AddColumn(StatisticColumn.Min);    // Ajoute la valeur minimale
            AddColumn(StatisticColumn.Max);    // Ajoute la valeur maximale
            AddExporter(MarkdownExporter.Default); // Export Markdown
            AddLogger(ConsoleLogger.Default); // Active les logs sur la console
            AddExporter(HtmlExporter.Default); // Génère un rapport HTML
        }
    }

    [GlobalSetup]
    public void Setup()
    {
        products = Enumerable.Range(0, NumberOfProducts)
            .Select(i => new Product { Id = i, Name = $"Product {i}", Price = i * 10 })
            .ToList();

        numbersList = Enumerable.Range(0, NumberOfProducts).ToList();
        numbersArray = Enumerable.Range(0, NumberOfProducts).ToArray();
    }

    [IterationSetup]
    public void PrepareIteration()
    {
        GC.Collect(); // Forcer la collecte du GC
        GC.WaitForPendingFinalizers();
        GC.Collect(); // Recollecte
    }

    // ======= Benchmarks sur les produits =======

    [Benchmark]
    public List<Product> LinqSelectionP()
    {
        return products.Where(p => p.Price % 2 == 0).ToList();
    }

    [Benchmark]
    public List<Product> ForLoopSelectionP()
    {
        var expensiveProducts = new List<Product>();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Price % 2 == 0)
            {
                expensiveProducts.Add(products[i]);
            }
        }
        return expensiveProducts;
    }
    
    [Benchmark]
    public List<Product> ForEachLoopSelectionP()
    {
        var expensiveProducts = new List<Product>();
        foreach (var product in products)
        {
            if (product.Price % 2 == 0)
            {
                expensiveProducts.Add(product);
            }
        }
        return expensiveProducts;
    }

    // ======= Benchmarks sur les nombres : List<int> =======

    [Benchmark]
    public List<int> ListLinqSelectionN()
    {
        return numbersList.Where(n => n % 2 == 0).ToList();
    }

    [Benchmark]
    public List<int> ListForLoopSelectionN()
    {
        var evenNumbers = new List<int>();
        for (int i = 0; i < numbersList.Count; i++)
        {
            if (numbersList[i] % 2 == 0)
            {
                evenNumbers.Add(numbersList[i]);
            }
        }
        return evenNumbers;
    }

    [Benchmark]
    public List<int> ListForeachSelectionN()
    {
        var evenNumbers = new List<int>();
        foreach (var number in numbersList)
        {
            if (number % 2 == 0)
            {
                evenNumbers.Add(number);
            }
        }
        return evenNumbers;
    }

    // ======= Benchmarks sur les nombres : int[] =======

    [Benchmark]
    public List<int> ArrayLinqSelectionA()
    {
        return numbersArray.Where(n => n % 2 == 0).ToList();
    }

    [Benchmark]
    public List<int> ArrayForLoopSelectionA()
    {
        var evenNumbers = new List<int>();
        for (int i = 0; i < numbersArray.Length; i++)
        {
            if (numbersArray[i] % 2 == 0)
            {
                evenNumbers.Add(numbersArray[i]);
            }
        }
        return evenNumbers;
    }

    [Benchmark]
    public List<int> ArrayForeachSelectionA()
    {
        var evenNumbers = new List<int>();
        foreach (var number in numbersArray)
        {
            if (number % 2 == 0)
            {
                evenNumbers.Add(number);
            }
        }
        return evenNumbers;
    }
}
