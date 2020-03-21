using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string[] words = phrase
            .Split(' ', '-', '_')
            .Where((word) => !String.IsNullOrWhiteSpace(word))
            .ToArray();
        return String.Concat(words.Select( w => w[0] )).ToUpper();
    }
}