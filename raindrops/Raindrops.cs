using System;
using System.Linq;
using System.Collections.Generic;

public static class Raindrops
{
    public static string Convert(int number)
    {
        string result = "";

        var factors = Enumerable
            .Range(1, number)
            .Where(x => number % x == 0);

        if (factors.Contains(3)) result += "Pling";

        if (factors.Contains(5)) result += "Plang";

        if (factors.Contains(7)) result += "Plong";

        if (result.Length == 0) result = number.ToString();

        return result;
    }
}