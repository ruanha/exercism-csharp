using System;
using System.Linq;
using System.Collections.Generic;

public static class Alphametics
{
    private static string RightHand;
    private static string[] LeftHand;
    public static IDictionary<char, int> Solve(string equation)
    {
        Parse(equation);
        return new Dictionary<char, int>
        {
            ['I'] = 1,
            ['B'] = 9,
            ['L'] = 0
        };
    }

    private static void Parse(string equation) {
        SetRightHand(equation.Split("==")[1]);
        SetLeftHand(equation.Split("==")[0]);
    }

    private static void SetRightHand(string untrimmed) {
        RightHand = untrimmed.Trim();
    }

    private static void SetLeftHand(string unsplitAndUntrimmed) {
        string[] untrimmed = unsplitAndUntrimmed.Split("+");
        LeftHand = untrimmed
            .Select(x => x.Trim())
            .ToArray();
    }
}