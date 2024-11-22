// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using BenchmarkDotNet.Running;
using leetcode.TestingThings;
using leetcode.TestingThings.LINQPerf;

Console.WriteLine("Hello, World!");

//UnderstandingYield.TestingYield();
// var stopwatch = Stopwatch.StartNew();
BenchmarkRunner.Run<MyBenchmark>();
// stopwatch.Stop();
//
// Console.WriteLine($"Total runtime: {stopwatch.ElapsedMilliseconds} ms");


// const int numberOfProducts = 1_000_000;
// List<Product> products = ProductGenerator.GenerateProducts(numberOfProducts);
//
// var tester = new PerformanceTester(products);
//
// Console.WriteLine("Performance Test: LINQ vs. for-loop\n");
//
// tester.TestInsertion(numberOfProducts);
// tester.TestSelection();
// tester.TestModification();
// tester.TestDeletion();
