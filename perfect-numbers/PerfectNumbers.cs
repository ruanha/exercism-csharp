using System;
using System.Linq;

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1) throw new ArgumentOutOfRangeException();

        int sumOfFactors = Enumerable
            .Range  (1, number/2)
            .Where  (x => number % x == 0)
            .ToList ()
            .Sum    ();

        return (Classification) sumOfFactors.CompareTo(number);
    }
}

public enum Classification
{
    Perfect = 0,
    Abundant = 1,
    Deficient = -1
}