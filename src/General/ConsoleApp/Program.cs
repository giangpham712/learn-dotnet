// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using ConsoleApp.Expressions;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<Example>();