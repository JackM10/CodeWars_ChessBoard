using System;
using System.Collections.Generic;
public class ChessBoard
{
    public static Dictionary<int, int> Count(int[][] b)
    {
        var result = new Dictionary<int, int>();
        var amountOfZeroes = AmountOfZeroes(b);
        var amountOfElements = b.Length * b.Length;

        //most fast (all zeroes or (ToDO) no any 2x2)
        if (amountOfZeroes == amountOfElements)
        {
            return result;
        }

        //fast (all ones):
        if (amountOfZeroes == 0)
        {
            CalculateAmountOfIncludedSquares(ref result, b.Length);

            return result;
        }

        //slow (counting biggest squares and applying math for counting included sq in them)
        //CountAllSquaresInChessBoard(ref result, b);
        MostStupidImplementation(ref result, b);

        return result;
    }

    private static void MostStupidImplementation(ref Dictionary<int, int> result, int[][] b)
    {
        for (int i = 0; i < b.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                if (b[i][j] == 1) FindSquaresAndAdd(ref result, b, i, j);
            }
        }
    }

    private static void FindSquaresAndAdd(ref Dictionary<int, int> result, int[][] b, int i, int j)
    {
        var twoByTwoWasSucceed = false;
        var foundSquareSize = 2;
        var indexM = i + 1;
        var indexN = j + 1;
        if (indexM < b.Length && indexN < b.Length)
        {
            if (b[indexM][j] == 1 && b[i][indexN] == 1 && b[indexM][indexN] == 1)
            {
                AddToDictionary(ref result, foundSquareSize);
                twoByTwoWasSucceed = true;
            }
        }

        if (twoByTwoWasSucceed)
        {
            var currentSqSizeToCheck = 3;
            var currentSqWasFound = true;
            
            for (int m = i; m < b.Length; m++)
            {
                if (currentSqWasFound)
                {
                    var sizeOfAllElementsInFoundSq = 0;
                    ++indexM;
                    ++indexN;
                    if (indexM < b.Length && indexN < b.Length)
                    {
                        for (int k = 0; k < currentSqSizeToCheck; k++)
                        {
                            for (int l = 0; l < currentSqSizeToCheck; l++)
                            {
                                if (b[i + k][j + l] == 1)
                                {
                                    sizeOfAllElementsInFoundSq++;
                                }
                                else
                                {
                                    currentSqWasFound = false;
                                    break; //ToDo: тут нужно выйти из 2х фориков
                                }
                            }
                        }

                        if (sizeOfAllElementsInFoundSq == currentSqSizeToCheck * currentSqSizeToCheck)
                        {
                            AddToDictionary(ref result, currentSqSizeToCheck);
                            currentSqSizeToCheck++;
                        }
                    }
                }
            }
        }
    }

    private static void AddToDictionary(ref Dictionary<int, int> dict, int squareSize)
    {
        var added = dict.TryAdd(squareSize, 1);
        if (!added)
        {
            dict[squareSize]++;
        }
    }


    private static void CalculateAmountOfIncludedSquares(ref Dictionary<int, int> dict, int squareSize)
    {
        if (squareSize <= 1) return;

        var counter = 0;
        for (var i = squareSize; i >= 2; i--)
        {
            if (i == squareSize)
            {
                dict.Add(i, 1);
                continue;
            }
            if (i == squareSize - 1)
            {
                dict.Add(i, 4);
                counter = 3;
                continue;
            }

            if (dict.ContainsKey(i))
            {
                dict[i]++;
            }
            dict.Add(i, dict[i + 1] + (counter + 2));
            counter += 2;
        }
    }


    private static int AmountOfZeroes(int[][] b)
    {
        var result = 0;

        for (int i = 0; i < b.Length; i++) //ToDo: to check which is faster i or j first
        {
            for (int j = 0; j < b.Length; j++)
            {
                if (b[i][j] == 0) result++;
            }
        }

        return result;
    }
}


public class tmp
{
    //2nd implementation (not working)

    private static void CountAllSquaresInChessBoard(ref Dictionary<int, int> result, int[][] b)
    {
        for (int i = 0; i < b.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                if (b[i][j] == 1) CalculateAmountOfIncludedSquares(ref result, CalculateSizeOfSquareAtPoint(b, i, j));
            }
        }
    }

    private static int CalculateSizeOfSquareAtPoint(int[][] b, int i, int j)
    {
        var counter = 1;

        for (int m = i; m < b.Length; m++)
        {
            for (int n = j; n < b.Length; n++)
            {
                var indexM = m + 1;
                var indexN = n + 1;
                if (indexM < b.Length && indexN < b.Length)
                {
                    if (b[m][n] == 1 && b[indexM][n] == 1 && b[m][indexN] == 1 && b[indexM][indexN] == 1)
                    {
                        counter++;
                    }
                }
            }
        }

        return counter;
    }


    private static int AmountOfZeroes(int[][] b)
    {
        var result = 0;

        for (int i = 0; i < b.Length; i++) //ToDo: to check which is faster i or j first
        {
            for (int j = 0; j < b.Length; j++)
            {
                if (b[i][j] == 0) result++;
            }
        }

        return result;
    }

    private static void CalculateAmountOfIncludedSquares(ref Dictionary<int, int> dict, int squareSize)
    {
        if (squareSize <= 1) return;

        var counter = 0;
        for (var i = squareSize; i >= 2; i--)
        {
            if (i == squareSize)
            {
                dict.Add(i, 1);
                continue;
            }
            if (i == squareSize - 1)
            {
                dict.Add(i, 4);
                counter = 3;
                continue;
            }

            if (dict.ContainsKey(i))
            {
                dict[i]++;
            }
            dict.Add(i, dict[i + 1] + (counter + 2));
            counter += 2;
        }
    }
}