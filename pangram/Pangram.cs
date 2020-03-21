using System;
using System.Linq;

public static class Pangram
{
    private static char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();
    public static bool IsPangram(string input)
    {
        var lowercaseInput = input.ToLower();
        var counter = new int[alphabet.Length];

        foreach (char c in lowercaseInput) {
            if ( alphabet.Contains(c) ) {
                counter[Array.IndexOf(alphabet, c)] = 1;
            }
        }

        if (counter.Sum() == alphabet.Length) {
            return true;
        }
        return false;
    }
}
