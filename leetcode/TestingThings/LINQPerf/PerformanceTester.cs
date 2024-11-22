using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using leetcode.TestingThings.LINQPerf;

public class PerformanceTester
{
    private List<Product> _products;

    public PerformanceTester(List<Product> products)
    {
        _products = products;
    }

    public void TestInsertion(int numberOfProducts)
    {
        Console.WriteLine("Insertion Test:");

        MeasureAverageTime(() =>
        {
            var newProducts = new List<Product>();
            for (int i = 0; i < numberOfProducts; i++)
            {
                newProducts.Add(new Product { Id = i, Name = $"Product {i}", Price = i * 10 });
            }
        }, "for-loop");

        MeasureAverageTime(() =>
        {
            var newProducts = Enumerable.Range(0, numberOfProducts)
                .Select(i => new Product { Id = i, Name = $"Product {i}", Price = i * 10 })
                .ToList();
        }, "LINQ");
    }

    public void TestSelection()
    {
        Console.WriteLine("\nSelection Test:");

        MeasureAverageTime(() =>
        {
            var expensiveProducts = _products.Where(p => p.Price > 500_000).ToList();
        }, "LINQ");

        MeasureAverageTime(() =>
        {
            var expensiveProducts = new List<Product>();
            foreach (var product in _products)
            {
                if (product.Price > 500_000)
                {
                    expensiveProducts.Add(product);
                }
            }
        }, "for-loop");
    }

    public void TestModification()
    {
        Console.WriteLine("\nModification Test:");

        MeasureAverageTime(() =>
        {
            foreach (var product in _products)
            {
                product.Price *= 1.1m;
            }
        }, "for-loop");

        MeasureAverageTime(() =>
        {
            _products.ForEach(p => p.Price *= 1.1m);
        }, "LINQ");
    }

    public void TestDeletion()
    {
        Console.WriteLine("\nDeletion Test:");

        MeasureAverageTime(() =>
        {
            _products.RemoveAll(p => p.Price > 500_000);
        }, "LINQ");

        MeasureAverageTime(() =>
        {
            var newList = new List<Product>();
            foreach (var product in _products)
            {
                if (product.Price <= 500_000)
                {
                    newList.Add(product);
                }
            }
            _products = newList;
        }, "for-loop");
    }

    private void MeasureAverageTime(Action action, string method, int repetitions = 10)
    {
        var totalMilliseconds = 0L;
        for (int i = 0; i < repetitions; i++)
        {
            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            totalMilliseconds += stopwatch.ElapsedMilliseconds;
        }
        Console.WriteLine($"{method} (avg over {repetitions} runs): {totalMilliseconds / repetitions} ms");
    }
}
