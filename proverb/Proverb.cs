using System;
using System.Collections.Generic;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        var result = new List<string>();

        if (subjects.Length == 0)
            return subjects;

        var lastVerse = $"And all for the want of a {subjects.First()}.";

        for (int i = 1; i < subjects.Length; i++) {
            result.Add($"For want of a {subjects[i-1]} the {subjects[i]} was lost.");
        }

        return result.Append(lastVerse).ToArray();
    }
}