using System;
using System.Linq;
using System.Collections.Generic;

public static class ScrabbleScore
{
    public static int Score(string input) => 
        input.Sum(c => ScoreLetter(char.ToUpperInvariant(c)));
    

    private static int ScoreLetter(char c) {
        foreach (var item in Scores) {
            if (item.Value.Contains(c)) {
                return item.Key;
            }
        }
        return 0;
    }

    private static Dictionary<int, List<char>> Scores = 
        new Dictionary<int, List<char>> {
            {1, new List<char>{'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'}},
            {2, new List<char>{'D', 'G'}},
            {3, new List<char>{'B', 'C', 'M', 'P'}},
            {4, new List<char>{'F', 'H', 'V', 'W', 'Y'}},
            {5, new List<char>{'K'}},
            {8, new List<char>{'J', 'X'}},
            {10, new List<char>{'Q', 'Z'}}
        };
}
