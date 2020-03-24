using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) =>Enumerable
        .Range  (1, max)
        .Sum    ()
        .Square ();
    public static int CalculateSumOfSquares(int max) => Enumerable
        .Range  (1, max)
        .Select (n => Square(n))
        .Sum    ();

    public static int CalculateDifferenceOfSquares(int max) => 
        Math.Abs(CalculateSumOfSquares(max) - CalculateSquareOfSum(max));

    static int Square(this int value)
        => value * value;
}