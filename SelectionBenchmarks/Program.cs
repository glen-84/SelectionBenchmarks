using BenchmarkDotNet.Running;
using SelectionBenchmarks;

BenchmarkSwitcher
    .FromAssembly(typeof(Program).Assembly)
    .Run(args);
