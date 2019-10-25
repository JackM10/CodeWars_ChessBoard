using System;
using NUnit.Framework;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class SolutionTest
{
    [Test]
    public void tmptest1()
    {
        var chessBoard = new int[][]
        {
            new int[] {1,1},
            new int[] {1,1}
        };
        Assert.AreEqual(new Dictionary<int, int> { [2] = 1 }, ChessBoard.Count(chessBoard));
    }

    [Test]
    public void tmptest2()
    {
        var chessBoard = new int[][]
        {
            new int[] {0,1},
            new int[] {1,1}
        };
        Assert.AreEqual(new Dictionary<int, int>(), ChessBoard.Count(chessBoard));
    }

    [Test]
    public void tmptest3()
    {
        var chessBoard = new int[][]
        {
            new int[] {1,1,1},
            new int[] {1,1,1},
            new int[] {1,1,1}
        };
        Assert.AreEqual(new Dictionary<int, int> { [2] = 4, [3] = 1 }, ChessBoard.Count(chessBoard));
    }

    [Test]
    public void tmptest4()
    {
        var chessBoard = new int[][]
        {
            new int[] {1,1,1},
            new int[] {1,0,1},
            new int[] {1,1,1}
        };
        Assert.AreEqual(new Dictionary<int, int>(), ChessBoard.Count(chessBoard));
    }

    [Test]
    public void tmptest5()
    {
        var chessBoard = new int[][]
        {
            new int[] {1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,0,1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,0,1,1,1,1,0, 1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,0,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,0,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1, 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 , 1,1,1,1,0,1,1,1,1,1},
            new int[] {1,1,1,1,1,1, 1,1,1,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 }
        };
        Assert.AreEqual(4, ChessBoard.Count(chessBoard).Count);
    }

    [Test]
    public void BasicTests()
    {

        var chessBoard = new int[][]
        {
            new int[] {1,1},
            new int[] {1,1}
        };
        Assert.AreEqual(new Dictionary<int, int> { [2] = 1 }, ChessBoard.Count(chessBoard));


        chessBoard = new int[][]
        {
            new int[] {0,1},
            new int[] {1,1}
        };
        Assert.AreEqual(new Dictionary<int, int>(), ChessBoard.Count(chessBoard));


        chessBoard = new int[][]
        {
            new int[] {1,1,1},
            new int[] {1,1,1},
            new int[] {1,1,1}
        };
        Assert.AreEqual(new Dictionary<int, int> { [2] = 4, [3] = 1 }, ChessBoard.Count(chessBoard));


        chessBoard = new int[][]
        {
            new int[] {1,1,1},
            new int[] {1,0,1},
            new int[] {1,1,1}
        };
        Assert.AreEqual(new Dictionary<int, int>(), ChessBoard.Count(chessBoard));


        chessBoard = new int[][]
        {
            new int[] {0,1,1,1,1},
            new int[] {1,1,1,1,1},
            new int[] {1,1,1,1,1},
            new int[] {0,1,1,0,1},
            new int[] {1,1,1,1,1}
        };
        Assert.AreEqual(new Dictionary<int, int> { [3] = 2, [2] = 9 }, ChessBoard.Count(chessBoard));
    }

    private const double BASIC_UNIT_TEST_PERFORMING_TIME_LIMIT = 1500; //Actual is about 1300 +\- 100
    private static double BasicUnitTestsOperationResults = double.MaxValue;

    [Test, Order(1)]
    public void JackPerformanceTests()
    {
        var benchmarkResults = BenchmarkRunner.Run<SolutionTest>();
        BasicUnitTestsOperationResults = benchmarkResults.Reports[0].ResultStatistics.Mean;

        Assert.True(!benchmarkResults.HasCriticalValidationErrors);
    }

    [Test]
    public void PerformaceBenchmark_AddOperation()
    {
        Assert.True(BasicUnitTestsOperationResults < BASIC_UNIT_TEST_PERFORMING_TIME_LIMIT);
    }

    [Benchmark]
    public void PerformAddOperation()
    {
        tmptest4();
    }
}